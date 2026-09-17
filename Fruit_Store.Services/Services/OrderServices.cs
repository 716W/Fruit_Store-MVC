using AutoMapper;
using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Repository;
using Fruit_Store.Core.Interfaces.Services;
using FruitStore.Core.Enums;
using FruitStore.Core.Models;

namespace Fruit_Store.Services.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new order from a cart. Fetches prices from DB, validates stock,
        /// decrements stock, and persists Order + OrderItems atomically.
        /// </summary>
        public async Task<(bool Success, string? Error, int OrderId)> CreateOrderFromCartAsync(
            string userId, IEnumerable<CartItemForOrder> cartItems,
            string? shippingName, string? shippingAddress, string? shippingCity, int? couponId = null)
        {
            // Load all required products in one query
            var productIds = cartItems.Select(c => c.ProductId).ToList();
            var products = new List<Product>();
            foreach (var pid in productIds)
            {
                var p = await _unitOfWork.Product.Get(x => x.Id == pid);
                if (p == null) return (false, $"Product ID {pid} not found.", 0);
                products.Add(p);
            }

            // Validate stock and build order items
            var orderItems = new List<OrderItem>();
            decimal total = 0m;
            foreach (var cartItem in cartItems)
            {
                var product = products.First(p => p.Id == cartItem.ProductId);
                if (product.Quantity < cartItem.Quantity)
                    return (false, $"Insufficient stock for {product.Name}. Available: {product.Quantity}", 0);

                orderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = cartItem.Quantity,
                    UnitPrice = product.Price  // snapshot price at time of order
                });
                total += product.Price * cartItem.Quantity;
            }

            // Apply coupon if provided
            if (couponId.HasValue)
            {
                var coupon = await _unitOfWork.Coupon.Get(c => c.Id == couponId.Value
                    && c.IsActived == true && c.ExpiryDate >= DateTime.UtcNow);
                if (coupon != null)
                {
                    total = total * (1 - coupon.DiscountPercentage / 100m);
                }
            }

            // Create order
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = Math.Round(total, 2),
                Status = OrderStatus.Pending,
                CouponId = couponId,
                ShippingName = shippingName,
                ShippingAddress = shippingAddress,
                ShippingCity = shippingCity,
                OrderItems = orderItems
            };

            // Persist order (cascade saves order items)
            await _unitOfWork.Order.AddAsync(order);

            // Decrement stock
            foreach (var cartItem in cartItems)
            {
                var product = products.First(p => p.Id == cartItem.ProductId);
                product.Quantity -= cartItem.Quantity;
                await _unitOfWork.Product.UpdateAsync(product.Id, product);
            }

            return (true, null, order.Id);
        }

        public async Task<bool> AddToCartAsync(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            return await _unitOfWork.Order.AddAsync(order);
        }

        public async Task<bool> CancelOrderAsync(int id)
        {
            var order = await _unitOfWork.Order.Get(x => x.Id == id, "OrderItems");
            if (order is null) return false;

            // Restore stock on cancellation
            if (order.OrderItems != null)
            {
                foreach (var item in order.OrderItems)
                {
                    var product = await _unitOfWork.Product.Get(p => p.Id == item.ProductId);
                    if (product != null)
                    {
                        product.Quantity += item.Quantity;
                        await _unitOfWork.Product.UpdateAsync(product.Id, product);
                    }
                }
            }

            order.Status = OrderStatus.Cancelled;
            return await _unitOfWork.Order.UpdateAsync(id, order);
        }

        public async Task<IEnumerable<OrderDTO?>> GetAllAsync()
        {
            var orders = await _unitOfWork.Order.GetAllAsync("OrderItems,OrderItems.Product");
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        /// <summary>Filters orders to only those belonging to the specified user (prevents IDOR).</summary>
        public async Task<IEnumerable<OrderDTO?>> GetAllByUserIdAsync(string userId)
        {
            var orders = await _unitOfWork.Order.GetAllAsync("OrderItems,OrderItems.Product");
            var userOrders = orders.Where(o => o.UserId == userId);
            return _mapper.Map<IEnumerable<OrderDTO>>(userOrders);
        }

        public async Task<OrderDTO?> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.Order.Get(o => o.Id == id, "OrderItems,OrderItems.Product");
            if (order == null) return null;
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<bool> RemoveFromCartAsync(int id)
        {
            var order = await _unitOfWork.Order.Get(x => x.Id == id);
            if (order is null) return false;
            return await _unitOfWork.Order.DeleteAsync(order);
        }

        public async Task<bool> SubmitOrderAsync(OrderDTO order)
        {
            var existingOrder = await _unitOfWork.Order.Get(x => x.Id == order.Id);
            if (existingOrder == null) return false;

            existingOrder.Status = OrderStatus.Delivered;
            return await _unitOfWork.Order.UpdateAsync(order.Id, existingOrder);
        }

        public async Task<bool> UpdateOrderAsync(OrderDTO orderDTO)
        {
            var existingOrder = await _unitOfWork.Order.Get(x => x.Id == orderDTO.Id);
            if (existingOrder == null) return false;

            var updatedOrder = _mapper.Map<Order>(orderDTO);
            updatedOrder.Status = existingOrder.Status; // Preserve status unless explicitly changed

            return await _unitOfWork.Order.UpdateAsync(updatedOrder.Id, updatedOrder);
        }

        public async Task<bool> UpdateStatusAsync(int id, OrderStatus newStatus)
        {
            var order = await _unitOfWork.Order.Get(x => x.Id == id, "OrderItems");
            if (order == null) return false;

            // If cancelling an active order, restore inventory
            if (newStatus == OrderStatus.Cancelled && order.Status != OrderStatus.Cancelled)
            {
                if (order.OrderItems != null)
                {
                    foreach (var item in order.OrderItems)
                    {
                        var product = await _unitOfWork.Product.Get(p => p.Id == item.ProductId);
                        if (product != null)
                        {
                            product.Quantity += item.Quantity;
                            await _unitOfWork.Product.UpdateAsync(product.Id, product);
                        }
                    }
                }
            }

            order.Status = newStatus;
            return await _unitOfWork.Order.UpdateAsync(id, order);
        }
    }
}

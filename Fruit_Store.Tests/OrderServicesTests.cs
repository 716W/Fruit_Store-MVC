using System.Linq.Expressions;
using AutoMapper;
using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Repository;
using Fruit_Store.Services.Services;
using FruitStore.Core.Enums;
using FruitStore.Core.Models;
using Moq;
using Xunit;

namespace Fruit_Store.Tests
{
    public class OrderServicesTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProductRepository> _productRepoMock;
        private readonly Mock<IOrderRepository> _orderRepoMock;
        private readonly Mock<ICouponRepository> _couponRepoMock;
        private readonly OrderServices _orderServices;

        public OrderServicesTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _productRepoMock = new Mock<IProductRepository>();
            _orderRepoMock = new Mock<IOrderRepository>();
            _couponRepoMock = new Mock<ICouponRepository>();

            _unitOfWorkMock.Setup(u => u.Product).Returns(_productRepoMock.Object);
            _unitOfWorkMock.Setup(u => u.Order).Returns(_orderRepoMock.Object);
            _unitOfWorkMock.Setup(u => u.Coupon).Returns(_couponRepoMock.Object);

            _orderServices = new OrderServices(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateOrderFromCartAsync_WhenProductNotFound_ReturnsFailure()
        {
            _productRepoMock
                .Setup(p => p.Get(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<string?>()))
                .ReturnsAsync((Product?)null);

            var items = new List<CartItemForOrder> { new() { ProductId = 999, Quantity = 1 } };
            var (success, error, orderId) = await _orderServices.CreateOrderFromCartAsync(
                "user-1", items, "John Doe", "123 Main St", "Springfield");

            Assert.False(success);
            Assert.Contains("not found", error);
            Assert.Equal(0, orderId);
        }

        [Fact]
        public async Task CreateOrderFromCartAsync_WhenInsufficientStock_ReturnsFailureWithoutOrderCreation()
        {
            var product = new Product { Id = 1, Name = "Apple", Price = 2.50m, Quantity = 2 };
            _productRepoMock
                .Setup(p => p.Get(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<string?>()))
                .ReturnsAsync(product);

            var items = new List<CartItemForOrder> { new() { ProductId = 1, Quantity = 5 } };
            var (success, error, orderId) = await _orderServices.CreateOrderFromCartAsync(
                "user-1", items, "John Doe", "123 Main St", "Springfield");

            Assert.False(success);
            Assert.Contains("Insufficient stock", error);
            Assert.Equal(0, orderId);
            _orderRepoMock.Verify(o => o.AddAsync(It.IsAny<Order>()), Times.Never);
        }

        [Fact]
        public async Task CreateOrderFromCartAsync_WhenStockAvailable_DecrementsStockAndSavesOrder()
        {
            var product = new Product { Id = 1, Name = "Strawberry", Price = 4.50m, Quantity = 50 };
            _productRepoMock
                .Setup(p => p.Get(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<string?>()))
                .ReturnsAsync(product);

            _orderRepoMock
                .Setup(o => o.AddAsync(It.IsAny<Order>()))
                .ReturnsAsync(true);

            _productRepoMock
                .Setup(p => p.UpdateAsync(It.IsAny<int>(), It.IsAny<Product>()))
                .ReturnsAsync(true);

            var items = new List<CartItemForOrder> { new() { ProductId = 1, Quantity = 5 } };
            var (success, error, _) = await _orderServices.CreateOrderFromCartAsync(
                "user-123", items, "Jane Doe", "456 Elm St", "Metropolis");

            Assert.True(success);
            Assert.Null(error);
            Assert.Equal(45, product.Quantity); // 50 - 5 = 45
            _orderRepoMock.Verify(o => o.AddAsync(It.Is<Order>(ord =>
                ord.UserId == "user-123" &&
                ord.ShippingName == "Jane Doe" &&
                ord.TotalAmount == 22.50m &&
                ord.OrderItems!.Count == 1 &&
                ord.OrderItems.First().UnitPrice == 4.50m
            )), Times.Once);
        }

        [Fact]
        public async Task CancelOrderAsync_RestoresProductStock()
        {
            var product = new Product { Id = 1, Name = "Strawberry", Quantity = 10 };
            var order = new Order
            {
                Id = 10,
                Status = OrderStatus.Pending,
                OrderItems = new List<OrderItem>
                {
                    new() { ProductId = 1, Quantity = 4, UnitPrice = 4.50m }
                }
            };

            _orderRepoMock
                .Setup(o => o.Get(It.IsAny<Expression<Func<Order, bool>>>(), It.IsAny<string?>()))
                .ReturnsAsync(order);

            _productRepoMock
                .Setup(p => p.Get(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<string?>()))
                .ReturnsAsync(product);

            _productRepoMock
                .Setup(p => p.UpdateAsync(product.Id, product))
                .ReturnsAsync(true);

            _orderRepoMock
                .Setup(o => o.UpdateAsync(order.Id, order))
                .ReturnsAsync(true);

            var result = await _orderServices.CancelOrderAsync(10);

            Assert.True(result);
            Assert.Equal(14, product.Quantity); // 10 + 4 restored
            Assert.Equal(OrderStatus.Cancelled, order.Status);
        }

        [Fact]
        public async Task GetAllByUserIdAsync_FiltersOutOrdersBelongingToOtherUsers()
        {
            var orders = new List<Order>
            {
                new() { Id = 1, UserId = "alice", TotalAmount = 10m },
                new() { Id = 2, UserId = "bob", TotalAmount = 20m },
                new() { Id = 3, UserId = "alice", TotalAmount = 30m }
            };

            _orderRepoMock
                .Setup(o => o.GetAllAsync(It.IsAny<string?>()))
                .ReturnsAsync(orders);

            _mapperMock
                .Setup(m => m.Map<IEnumerable<OrderDTO>>(It.IsAny<IEnumerable<Order>>()))
                .Returns<IEnumerable<Order>>(src => src.Select(o => new OrderDTO { Id = o.Id, UserId = o.UserId }));

            var aliceOrders = (await _orderServices.GetAllByUserIdAsync("alice")).ToList();

            Assert.Equal(2, aliceOrders.Count);
            Assert.All(aliceOrders, o => Assert.Equal("alice", o!.UserId));
        }
    }
}

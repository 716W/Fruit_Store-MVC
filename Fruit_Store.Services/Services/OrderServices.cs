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

        public OrderServices(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper =mapper;
        }
        public async Task<bool> AddToCartAsync(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            return await _unitOfWork.Order.AddAsync(order);
        }

        public async Task<bool> CancelOrderAsync(int id)
        {
            var order = await _unitOfWork.Order.Get(x => x.Id == id);
            if (order is null) return false;

            order.Status = OrderStatus.Cancelled ;
            return await _unitOfWork.Order.UpdateAsync(id, order);
        }

        public  async Task<IEnumerable<OrderDTO?>> GetAllAsync()
        {
            var order = await _unitOfWork.Order.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(order);
        }

        public async Task<IEnumerable<OrderDTO?>> GetAllByUserIdAsync(string userId)
        {
            var order = await _unitOfWork.Order.GetAllAsync(); // here must include user
            if (order == null) return Enumerable.Empty<OrderDTO>();

            //var userOrders = order.Where(o => o.UserId == userId);
            return _mapper.Map<IEnumerable<OrderDTO>>(order); // u should swap (order) => (userOrder) .
        }

        public async Task<OrderDTO?> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.Order.Get(o => o.Id == id , "OrderItems");
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
            var exsistingOrder = await _unitOfWork.Order.Get(x => x.Id == orderDTO.Id);
            if (exsistingOrder == null) return false;

            var updatedOrder = _mapper.Map<Order>(orderDTO);
            updatedOrder.Status = exsistingOrder.Status; // Preserve status

            return await _unitOfWork.Order.UpdateAsync(updatedOrder.Id, updatedOrder);

        }
    }
}


using AutoMapper;
using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Services;
using FruitStore.Core.Models;
using FruitStore.Infrastructure.Reposetory.Base;

namespace Fruit_Store.Services.Services
{
    public class OrderItemServices : IOrderItemServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderItemServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(OrderItemDTO Orderitem)
        {
            var orderITemEntity = _mapper.Map<OrderItem>(Orderitem);
            return await _unitOfWork.OrderItem.AddAsync(orderITemEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orderItem =await _unitOfWork.OrderItem.Get(x => x.Id == id);
            if (orderItem == null) return false;

            return await _unitOfWork.OrderItem.DeleteAsync(orderItem);
        }

        public async Task<IEnumerable<OrderItemDTO?>> GetAllAsync()
        {
            var orderItems = await _unitOfWork.OrderItem.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderItemDTO?>>(orderItems);
        }

        public async Task<OrderItemDTO?> GetByIdAsync(int id)
        {
            var orderItem = await _unitOfWork.OrderItem.Get(x => x.Id == id);
            if (orderItem == null) return null;

            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task<decimal> GetTotalForOrderAsync(int orderId)
        {
            var orderItems = await _unitOfWork.OrderItem.GetAllAsync("Product");
            orderItems = orderItems.Where(item => item.OrderId == orderId);

            if (!orderItems.Any())
                return 0;

            return orderItems.Sum(item => item.Quantity * item.UnitPrice);

        }

        public async Task<bool> UpdateAsync(OrderItemDTO Orderitem)
        {
            var orderITemEntity = await _unitOfWork.OrderItem.Get(x => x.Id == Orderitem.Id);
            if (orderITemEntity == null) return false;

            return await _unitOfWork.OrderItem.UpdateAsync(orderITemEntity.Id , _mapper.Map<OrderItem>(Orderitem));
        }
    }
}

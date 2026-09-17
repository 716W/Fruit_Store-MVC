using Fruit_Store.Core.DTOs;
using FruitStore.Core.Enums;

namespace Fruit_Store.Core.Interfaces.Services
{
    public interface IOrderServices
    {
        Task<IEnumerable<OrderDTO?>> GetAllByUserIdAsync(string userId);
        Task<IEnumerable<OrderDTO?>> GetAllAsync();
        Task<OrderDTO?> GetByIdAsync(int id);
        Task<bool> SubmitOrderAsync(OrderDTO order);
        Task<bool> CancelOrderAsync(int id);
        Task<bool> AddToCartAsync(OrderDTO orderDTO);
        Task<bool> UpdateOrderAsync(OrderDTO orderDTO);
        Task<bool> RemoveFromCartAsync(int id);
        Task<bool> UpdateStatusAsync(int id, OrderStatus newStatus);
        Task<(bool Success, string? Error, int OrderId)> CreateOrderFromCartAsync(
            string userId, IEnumerable<CartItemForOrder> cartItems,
            string? shippingName, string? shippingAddress, string? shippingCity, int? couponId = null);
    }
}

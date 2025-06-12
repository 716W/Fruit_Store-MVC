using Fruit_Store.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces
{
    public interface IOrderServices
    {
        Task<IEnumerable<OrderDTO>> GetAllByUserIdAsync(string userId);
        Task<IEnumerable<OrderDTO>> GetAllAsync();
        Task<OrderDTO> GetByIdAsync(int id);
        Task<bool> SubmitOrderAsync(OrderDTO order);
        Task<bool> CancelOrderAsync(int id);
        Task<bool> AddToCartAsync(OrderDTO orderDTO);
        Task<bool> UpdateOrderAsync(OrderDTO orderDTO);
        Task<bool> RemoveFromCartAsync(int id); 
    }
}

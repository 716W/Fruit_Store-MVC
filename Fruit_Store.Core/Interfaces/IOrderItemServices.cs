using Fruit_Store.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces
{
    public interface IOrderItemServices
    {
        Task<IEnumerable<OrderItemDTO?>> GetAllAsync();
        Task<OrderItemDTO?> GetByIdAsync(int id);
        Task<bool> AddAsync(OrderItemDTO Orderitem);
        Task<bool> UpdateAsync(OrderItemDTO Orderitem);
        Task<bool> DeleteAsync(int id);
        Task<decimal> GetTotalForOrderAsync(int orderId);
    }
}

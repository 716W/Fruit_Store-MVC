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
        Task<IEnumerable<OrderItemDTO>> GetAllAsync();
        Task<OrderItemDTO> GetByIdAsync(int id);
        Task AddAsync(OrderItemDTO Orderitem);
        Task UpdateAsync(OrderItemDTO Orderitem);
        Task DeleteAsync(int id);
    }
}

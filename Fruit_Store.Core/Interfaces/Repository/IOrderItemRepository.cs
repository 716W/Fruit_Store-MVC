using FruitStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces.Repository
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem,int>
    {
        Task<bool> UpdateAsync(int id, OrderItem orderItem);
    }
}

using FruitStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces.Repository
{
    public interface IOrderRepository : IGenericRepository<Order,int>
    {
        Task<bool> UpdateAsync(int id, Order order);
    }
}

using FruitStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Infrastructure.Reposetory.Base
{
    public interface IOrderRepository
    {
        Task<bool> UpdateAsync(int id, Order order);
    }
}

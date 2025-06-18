using FruitStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces.Repository
{
    public interface ICouponRepository : IGenericRepository<Coupon,int>
    {
        Task<bool> UpdateAsync(int id, Coupon coupon);
    }
}

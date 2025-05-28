using Fruit_Store.Infrastructure.Reposetory.Base;
using FruitStore.Core.Models;
using FruitStore.Fruit_Store.Infrastructure.Data;
using FruitStore.Infrastructure.Reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Infrastructure.Reposetory
{
    class CouponRepository : GenericReposetory<Coupon, int>, ICouponRepository
    {
        private readonly AppDbContext _context;
        public CouponRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> UpdateAsync(int id, Coupon coupon)
        {
            var existingEntity = await Get(x => x.Id == id);
            if (existingEntity is null) return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(coupon);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

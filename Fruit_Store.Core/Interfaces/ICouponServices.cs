using Fruit_Store.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces
{
    public interface ICouponServices
    {
        Task<IEnumerable<CouponDTO>> GetAllAsync();
        Task<CouponDTO> GetbyCodeAsync(string code);
        Task AddAsync(CouponDTO coupon);
        Task UpdateAsync(CouponDTO coupon);
        Task DeleteAsync(int id);
        Task<bool> VaildateCouponAsync(string code);
        Task<decimal> ApplyDiscountAsync(string code, decimal totalAmount);
    }
}

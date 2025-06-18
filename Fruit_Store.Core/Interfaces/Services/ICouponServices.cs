using Fruit_Store.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces.Services
{
    public interface ICouponServices
    {
        Task<IEnumerable<CouponDTO>> GetAllAsync();
        Task<CouponDTO?> GetbyCodeAsync(string code);
        Task<bool> AddAsync(CouponDTO coupon);
        Task<bool> UpdateAsync(CouponDTO coupon);
        Task<bool> DeleteAsync(int id);
        Task<bool> VaildateCouponAsync(string code);
        Task<decimal> ApplyDiscountAsync(string code, decimal totalAmount);
    }
}

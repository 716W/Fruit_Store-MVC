using AutoMapper;
using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Services;
using FruitStore.Core.Models;
using FruitStore.Infrastructure.Reposetory.Base;

namespace Fruit_Store.Services.Services
{
    class CouponServices : ICouponServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CouponServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(CouponDTO coupon)
        {
            var couponEntity = _mapper.Map<Coupon>(coupon);
            return await _unitOfWork.Coupon.AddAsync(couponEntity);
        }

        public async Task<decimal> ApplyDiscountAsync(string code, decimal totalAmount)
        {
            if (string.IsNullOrWhiteSpace(code) || totalAmount <= 0)
                return 0;

            var coupon = await _unitOfWork.Coupon.Get(x => x.Code == code && x.IsActived == true);

            if (coupon == null || coupon.ExpiryDate < DateTime.UtcNow)
                return 0;

            decimal discountAmount = (coupon.DiscountPercentage / 100m) * totalAmount;

            return discountAmount;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var existingCoupon = await _unitOfWork.Coupon.Get(x => x.Id == id);
            if (existingCoupon == null) return false;

            return await _unitOfWork.Coupon.DeleteAsync(existingCoupon);
        }

        public async Task<IEnumerable<CouponDTO>> GetAllAsync()
        {
            var coupons = await _unitOfWork.Coupon.GetAllAsync();
            return _mapper.Map<IEnumerable<CouponDTO>>(coupons);
        }

        public async Task<CouponDTO?> GetbyCodeAsync(string code)
        {
            var coupon = await  _unitOfWork.Coupon.Get(X => X.Code == code);
            if (coupon == null) return null;

            return _mapper.Map<CouponDTO>(coupon);
        }

        public async Task<bool> UpdateAsync(CouponDTO coupon)
        {
            var esistingCoupon = await _unitOfWork.Coupon.Get(x => x.Id == coupon.Id);
            if (esistingCoupon == null) return false;

            var updateCoupon = _mapper.Map<Coupon>(coupon);
            return await _unitOfWork.Coupon.UpdateAsync(esistingCoupon.Id,updateCoupon);
        }

        public async Task<bool> VaildateCouponAsync(string code)
        {
            var coupon = await _unitOfWork.Coupon.Get(x => x.Code == code && x.IsActived == true && x.ExpiryDate > DateTime.Now);

            if (coupon == null)
            {
                return false;
            }
            return true;
        }
    }
}

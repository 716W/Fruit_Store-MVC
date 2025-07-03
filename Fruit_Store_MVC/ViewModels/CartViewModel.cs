using Fruit_Store.Core.DTOs;

namespace Fruit_Store_MVC.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable <OrderDTO> orders { get; set; }
        public IEnumerable<CouponDTO> coupons { get; set; }
    }
}

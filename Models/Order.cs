using Fruit_Store_MVC.Enums;

namespace Fruit_Store_MVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus? Status { get; set; } = OrderStatus.Pending;

        // Foreign Keys
        public int? UserId { get; set; } // foreign key for User
        public int? CouponId { get; set; } // foreign key for Cupon

        // Navagation Property
        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
        public Coupon? Coupon { get; set; }
    }
}


using FruitStore.Core.Enums;

namespace FruitStore.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus? Status { get; set; } = OrderStatus.Pending;

        // Foreign Keys
        public string? UserId { get; set; } // foreign key for IdentityUser (string ID)
        public int? CouponId { get; set; } // foreign key for Coupon

        // Shipping info (snapshot at order time)
        public string? ShippingName { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }

        // Navigation Property
        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
        public Coupon? Coupon { get; set; }
    }
}

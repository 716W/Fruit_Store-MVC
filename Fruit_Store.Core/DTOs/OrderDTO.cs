using FruitStore.Core.Enums;

namespace Fruit_Store.Core.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus? Status { get; set; } = OrderStatus.Pending;

        // Foreign Keys
        public string? UserId { get; set; }
        public int? CouponId { get; set; }

        // Shipping info
        public string? ShippingName { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }

        // Navigation
        public List<OrderItemDTO> Items { get; set; } = new();
    }
}

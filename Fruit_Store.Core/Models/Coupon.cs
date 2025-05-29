namespace FruitStore.Core.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ?Code { get; set; }
        public decimal DiscountPercentage { get; set; } // e.g., 10 for 10%
        public DateTime ExpiryDate { get; set; }
        public bool ? IsActived { get; set; }

        // Navagtion Property
        public ICollection<Order>? Orders { get; set; }
    }
}

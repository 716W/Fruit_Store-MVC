namespace Fruit_Store_MVC.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ?Code { get; set; }
        public int? Value { get; set; }
        public DateTime? ExDate { get; set; }
        public bool ? IsActived { get; set; }

        // Navagtion Property
        public ICollection<Product>? Products { get; set; }
    }
}

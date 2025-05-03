namespace Fruit_Store_MVC.Models
{
    public class OrderItem
    {
        public int Id { get; set; } // Primary Key
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Foreign Keys
        public int OrderId { get; set; } // foreign key for Order
        public int ProductId { get; set; } // foreign key for Product

        // Navagation Properties
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}

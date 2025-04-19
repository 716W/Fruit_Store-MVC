using System.ComponentModel.DataAnnotations.Schema;

namespace Fruit_Store_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }   // foreign key for Category
        
        // Navagation Properties
        public Category Category { get; set; } = new Category();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}

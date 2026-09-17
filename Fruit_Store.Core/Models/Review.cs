namespace FruitStore.Core.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now ;

        // Foregin Keys 
        public string? UserId { get; set; } // foreign key for IdentityUser (string ID)
        public int ProductId { get; set; }

        // Navagtion Property
        public Product? Product { get; set; }
    }
}

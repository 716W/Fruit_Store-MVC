namespace FruitStore.Core.Models
{
    public class Category
    {
        public int Id { get; set;}
        public string? Name { get; set;}

        // Navagation Properties
        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}

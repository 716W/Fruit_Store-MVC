using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.ViewModels
{
    public class ProductViewModel
    {
        public Product? Product { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Category>? categories { get; set; }
    }
}

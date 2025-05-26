using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.ViewModels
{
    public class ShopViewModel
    {
        public ICollection<Product>? Products { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}

using FruitStore.Core.Models;

namespace FruitStore.MVC.ViewModels
{
    public class ShopViewModel
    {
        public ICollection<Product>? Products { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}

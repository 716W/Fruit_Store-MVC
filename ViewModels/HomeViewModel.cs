using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Product>? Products { get; set; }
        public ICollection<New>? News { get; set; }
        public ICollection<Review>? Reviews { get; set; }

    }
}

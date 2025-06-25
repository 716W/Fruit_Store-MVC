using Fruit_Store.Core.DTOs;
using FruitStore.Core.Models;

namespace FruitStore.Fruit_Store_MVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ProductDTO>? Products { get; set; }
        public IEnumerable<NewDTO>? News { get; set; }
        public IEnumerable<ReviewDTO>? Reviews { get; set; }

    }
}

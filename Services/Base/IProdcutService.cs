using Fruit_Store_MVC.Models;
using Fruit_Store_MVC.ViewModels;

namespace Fruit_Store_MVC.Services.Base
{
    public interface IProdcutService
    {
        Task<ProductViewModel> GetAllAsync();
        Task<ProductViewModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(ProductViewModel productViewModel , IFormFile imageFile);
        Task<bool> UpdateAsync(ProductViewModel productViewModel , IFormFile? imageFile);
        Task<bool> DeleteAsync(int id);

    }
}

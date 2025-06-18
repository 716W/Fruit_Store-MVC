using Fruit_Store.Core.DTOs;

namespace Fruit_Store.Core.Interfaces.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetById(int id);
        Task<bool> AddAsync(CategoryDTO categoryDTO);
        Task<bool> UpdateAsync(CategoryDTO categoryDTO);
        Task<bool> DeleteAsync(int id);
    }
}

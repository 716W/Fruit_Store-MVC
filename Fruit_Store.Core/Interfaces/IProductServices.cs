using Fruit_Store.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetByIdAsync(int id);
        Task<bool> AddAsync(ProductDTO productDTO);
        Task<bool> UpdateAsync(ProductDTO productDTO);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProductDTO>> GetByCategoryIdAsync(int categoryId);
        
    }
}

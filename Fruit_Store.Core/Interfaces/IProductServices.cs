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
        Task<ProductDTO> GetByIdAsync(int id);
        Task AddAsync(ProductDTO productDTO);
        Task UpdateAsync(ProductDTO productDTO);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductDTO>> GetByCategoryIdAsync(int categoryId);
        
    }
}

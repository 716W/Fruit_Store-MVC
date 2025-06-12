using Fruit_Store.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces
{
    public interface IReviewServices
    {
        Task<IEnumerable<ReviewDTO>> GetAllAsync();
        Task<ReviewDTO> GetByIdAsync(int id);
        Task AddAsync(ReviewDTO reviewDTO);
        Task UpdateAsync(ReviewDTO reviewDTO);
        Task DeleteAsync(int id);
        Task<IEnumerable<ReviewDTO>> GetByProductIdAsync(int productId);
        Task<IEnumerable<ReviewDTO>> GetByUserIdAsync(string userId);
        Task<IEnumerable<ReviewDTO>> GetLastReviewsAsync();
    }
}

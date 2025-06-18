using Fruit_Store.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces.Services
{
    public interface IReviewServices
    {
        Task<IEnumerable<ReviewDTO>> GetAllAsync();
        Task<ReviewDTO?> GetByIdAsync(int id);
        Task<bool> AddAsync(ReviewDTO reviewDTO);
        Task<bool> UpdateAsync(ReviewDTO reviewDTO);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ReviewDTO>> GetByProductIdAsync(int productId);
        Task<IEnumerable<ReviewDTO>> GetByUserIdAsync(string userId);
        Task<IEnumerable<ReviewDTO>> GetLastReviewsAsync();
    }
}

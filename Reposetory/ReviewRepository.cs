using Fruit_Store_MVC.Data;
using Fruit_Store_MVC.Models;
using Fruit_Store_MVC.Reposetory.Base;
using Microsoft.EntityFrameworkCore;

namespace Fruit_Store_MVC.Reposetory
{
    public class ReviewRepository :  GenericReposetory<Review,int> , IReviewRepository
    {
        private readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> UpdateAsync(int id, Review review)
        {
            var existingEntity = await GetByIdAsync(x => x.Id == id);
            if (existingEntity == null) return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

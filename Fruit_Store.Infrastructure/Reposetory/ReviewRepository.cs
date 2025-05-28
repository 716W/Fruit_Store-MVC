using FruitStore.Core.Models;
using FruitStore.Fruit_Store.Infrastructure.Data;
using FruitStore.Infrastructure.Data;
using FruitStore.Infrastructure.Reposetory.Base;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Infrastructure.Reposetory
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
            var existingEntity = await Get(x => x.Id == id);
            if (existingEntity == null) return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using AutoMapper;
using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Services;
using FruitStore.Core.Models;
using FruitStore.Infrastructure.Reposetory.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Services.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ReviewServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(ReviewDTO reviewDTO)
        {
            var review = _mapper.Map<Review>(reviewDTO);
            return await _unitOfWork.Review.AddAsync(review);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var review = await _unitOfWork.Review.Get(x => x.Id == id);
            if (review is null)
                return false;

            return await _unitOfWork.Review.DeleteAsync(review);
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllAsync()
        {
            var reviews = await _unitOfWork.Review.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<ReviewDTO?> GetByIdAsync(int id)
        {
            var review = _unitOfWork.Review.Get(x => x.Id == id);

            if (review == null) return null;

            return await Task.FromResult(_mapper.Map<ReviewDTO>(review));

        }

        public async Task<IEnumerable<ReviewDTO>> GetByProductIdAsync(int productId)
        {
            var reviews = await _unitOfWork.Review.GetAllAsync("Product");

            var filteredReviews = reviews.Where(r => r.ProductId == productId);
            return _mapper.Map<IEnumerable<ReviewDTO>>(filteredReviews);
        }

        public async Task<IEnumerable<ReviewDTO>> GetByUserIdAsync(string userId)
        {
            var reviews = await _unitOfWork.Review.GetAllAsync("User");

            // if u make user Entity solve this and make code unChecked .
            //var filteredReviews = reviews.Where(r => r.UserId == userId);

            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);

            
        }

        public async Task<IEnumerable<ReviewDTO>> GetLastReviewsAsync()
        {
            var reviews = await _unitOfWork.Review.GetAllAsync();

            var lastTenReviews = reviews
                .OrderByDescending(r => r.Id) // Assuming higher Id means newer
                .Take(10);

            return _mapper.Map<IEnumerable<ReviewDTO>>(lastTenReviews);
        }

        public async Task<bool> UpdateAsync(ReviewDTO reviewDTO)
        {
            var existingReview = _unitOfWork.Review.Get(x => x.Id == reviewDTO.Id);

            if (existingReview is null) return false;

            var UpdateReview = _mapper.Map<Review>(reviewDTO);
            return await _unitOfWork.Review.UpdateAsync(reviewDTO.Id, UpdateReview);
        }
    }
}

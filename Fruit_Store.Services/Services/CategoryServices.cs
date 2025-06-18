using AutoMapper;
using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Services;
using FruitStore.Core.Models;
using FruitStore.Infrastructure.Reposetory.Base;

namespace Fruit_Store.Services.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryServices(IUnitOfWork unitOfWork , IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = Mapper;
        }
        public async Task<bool> AddAsync(CategoryDTO categoryDTO)
        {
            var Category = _mapper.Map<Category>(categoryDTO);
            return await _unitOfWork.Category.AddAsync(Category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _unitOfWork.Category.Get(c => c.Id == id);
            if (category == null)
            {
                return false; // or throw an exception if you prefer
            }
            return await _unitOfWork.Category.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var Categories = await _unitOfWork.Category.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(Categories);
        }

        public Task<CategoryDTO> GetById(int id)
        {
            var category = _unitOfWork.Category.Get(c => c.Id == id);

            if (category == null)
            {
                return Task.FromResult<CategoryDTO>(null); // or throw an exception if you prefer
            }
            return Task.FromResult(_mapper.Map<CategoryDTO>(category));
        }

        public Task<bool> UpdateAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            return  _unitOfWork.Category.UpdateAsync(categoryDTO.Id ,category);
        }


    }
}

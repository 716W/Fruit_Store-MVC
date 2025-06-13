using AutoMapper;
using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces;
using FruitStore.Core.Models;
using FruitStore.Infrastructure.Reposetory.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Services.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductServices(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        public Task<bool> AddAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            return _unitOfWork.Product.AddAsync(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Product.Get(x => x.Id == id);

            if (product == null)
                return false;

            return await _unitOfWork.Product.DeleteAsync(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var Product = await _unitOfWork.Product.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(Product);
        }
        

        public async Task<IEnumerable<ProductDTO>> GetByCategoryIdAsync(int categoryId)
        {
            var products = await _unitOfWork.Product.GetAllAsync("Category");
            var filtered = products.Where(x => x.CategoryId == categoryId);
            return _mapper.Map<IEnumerable<ProductDTO>>(filtered);
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Product.Get(x => x.Id == id);
            if (product == null)
                return null;

            return _mapper.Map<ProductDTO>(product);
        }

        public Task<bool> UpdateAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            return _unitOfWork.Product.UpdateAsync(productDTO.Id, product);
        }
    }
}

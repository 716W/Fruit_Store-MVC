using Fruit_Store_MVC.Models;
using Fruit_Store_MVC.Reposetory.Base;
using Fruit_Store_MVC.Services.Base;
using Fruit_Store_MVC.ViewModels;

namespace Fruit_Store_MVC.Services
{
    public class ProductService : IProdcutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public ProductService(IUnitOfWork unitOfWork , IImageService imageService)
        {
            _imageService = imageService;
            _unitOfWork = unitOfWork;   
        }
        public async Task<bool> CreateAsync(ProductViewModel productViewModel , IFormFile imageFile)
        {
            var product = new Product
            {
                Name = productViewModel.Product.Name,
                Price = productViewModel.Product.Price,
                Description = productViewModel.Product.Description,
                CategoryId = productViewModel.Product.CategoryId
            };

            if (imageFile != null)
            {
                product.ImageUrl = await _imageService.CreateImageAsync(imageFile, "Products");
            }

            return await _unitOfWork.Product.AddAsync(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Product.Get(x => x.Id == id);
            if (product is null)
            {
                return await Task.FromResult(false);
            }
            else
            {
                return await _unitOfWork.Product.DeleteAsync(product);
            }
        }

        public async Task<ProductViewModel> GetAllAsync()
        {
            var products = (await _unitOfWork.Product.GetAllAsync(includeProperties:"Category")).OfType<Product>().ToList();

            var ViewMod = new ProductViewModel
            {
                Products = products,
                categories = products.Select(p => p.Category).Distinct().OfType<Category>().ToList() 
            };
            return ViewMod;
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Product.Get(x => x.Id == id, includeProperties: "Category");
            if (product is null)
            {
                return await Task.FromResult<ProductViewModel>(null);
            }
            else
            {
                var productViewModel = new ProductViewModel
                {
                    Product = product,
                    // maybe i don't need to get the all category , if u have seaniro to make something like this u can separte
                    // them by create other View Model to something for Deatils and something else to ProductFormOperation .
                     //categories = (await _unitOfWork.Category.GetAllAsync()).OfType<Category>().ToList(),
                };
                return await Task.FromResult(productViewModel);
            }
        }

        public Task<Product?> SearchAsync(string name)
        {
            return _unitOfWork.Product.Get(x => x.Name.ToLower().Contains(name.ToLower())
            , includeProperties: "Category"
            );
        }

        public async Task<bool> UpdateAsync(ProductViewModel productViewModel, IFormFile? imageFile)
        {
            var exsitProduct = await _unitOfWork.Product.Get(x => x.Id == productViewModel.Product.Id);
            if (exsitProduct == null)
            {
                return await Task.FromResult(false);
            }

            exsitProduct.Name = productViewModel.Product.Name;
            exsitProduct.Price = productViewModel.Product.Price;
            exsitProduct.Description = productViewModel.Product.Description;
            exsitProduct.CategoryId = productViewModel.Product.CategoryId;

            if (imageFile != null)
            {
                exsitProduct.ImageUrl = await _imageService.CreateImageAsync(imageFile, "Products");
            }

            return await _unitOfWork.Product.UpdateAsync(exsitProduct.Id, exsitProduct);
        }

    }
}

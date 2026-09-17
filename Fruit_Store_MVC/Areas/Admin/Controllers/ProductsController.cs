using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fruit_Store_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ProductsController(IProductServices productServices, ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productServices.GetAllAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateCategoriesAsync();
            return View(new ProductDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync();
                return View(model);
            }

            if (model.Price <= 0)
            {
                ModelState.AddModelError(nameof(model.Price), "Price must be greater than zero.");
                await PopulateCategoriesAsync();
                return View(model);
            }

            if (model.Quantity < 0)
            {
                ModelState.AddModelError(nameof(model.Quantity), "Quantity cannot be negative.");
                await PopulateCategoriesAsync();
                return View(model);
            }

            await _productServices.AddAsync(model);
            TempData["Success"] = "Product created successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productServices.GetByIdAsync(id);
            if (product == null) return NotFound();

            await PopulateCategoriesAsync(product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductDTO model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync(model.CategoryId);
                return View(model);
            }

            if (model.Price <= 0)
            {
                ModelState.AddModelError(nameof(model.Price), "Price must be greater than zero.");
                await PopulateCategoriesAsync(model.CategoryId);
                return View(model);
            }

            if (model.Quantity < 0)
            {
                ModelState.AddModelError(nameof(model.Quantity), "Quantity cannot be negative.");
                await PopulateCategoriesAsync(model.CategoryId);
                return View(model);
            }

            var result = await _productServices.UpdateAsync(model);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Update failed. Product may not exist.");
                await PopulateCategoriesAsync(model.CategoryId);
                return View(model);
            }

            TempData["Success"] = "Product updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productServices.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _productServices.DeleteAsync(id);
            if (!result)
            {
                TempData["Error"] = "Cannot delete product. It may be referenced by existing orders.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = "Product deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateCategoriesAsync(int? selectedId = null)
        {
            var categories = await _categoryServices.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", selectedId);
        }
    }
}

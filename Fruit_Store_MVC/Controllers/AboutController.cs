using Fruit_Store.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fruit_Store_MVC.Controllers
{
    public class AboutController : Controller
    {
        private readonly IReviewServices _reviewServices;
        public AboutController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var reviews = await _reviewServices.GetLastReviewsAsync();
            return View(reviews);
        }
    }
}

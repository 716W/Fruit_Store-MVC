using Fruit_Store_MVC.ViewModels;

namespace Fruit_Store_MVC.Services.Base
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetHomePageDataAsync();

    }
}

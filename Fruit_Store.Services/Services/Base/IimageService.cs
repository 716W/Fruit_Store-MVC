using Microsoft.AspNetCore.Http;

namespace FruitStore.Fruit_Store.Services.Services.Base
{
    public interface IImageService
    {
        public Task<string> CreateImageAsync(IFormFile file , string folderName);

        public Task<string> UpdateImageAsync(IFormFile file, string folderName, string? oldImageName);

    }
}

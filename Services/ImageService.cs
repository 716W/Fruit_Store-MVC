using Fruit_Store_MVC.Services.Base;

namespace Fruit_Store_MVC.Services
{
    /// <summary>
    /// Handles creation and update of image files for entities.
    /// - Automatically saves files under wwwroot/Images/{folderName}
    /// - Ensures folders are created if missing
    /// - Supports updating image by deleting old one and saving new
    /// </summary>
    /// /// <summary>
    
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageService(IWebHostEnvironment env)
        {
            _webHostEnvironment = env;
        }
        public async Task<string> CreateImageAsync(IFormFile file, string folderName)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(wwwRootPath, @"Images", folderName);

            // create the folder if it does not exist
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string fullFilePath = Path.Combine(filePath, fileName);

            using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Return the relative path for use in the application
            return $@"Images\{folderName}\{fileName}";
        }
        public async Task<string> UpdateImageAsync(IFormFile file, string folderName, string? oldImageName)
        {
            if (file != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (!string.IsNullOrEmpty(oldImageName))
                {
                    string oldImagePath = Path.Combine(wwwRootPath, oldImageName.TrimStart('\\'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
                return await CreateImageAsync(file, folderName);
            }

            // If no new file is provided, return the old image name (or null if it didn't exist) .
            return oldImageName ?? string.Empty;
        }
    }
    
    
}

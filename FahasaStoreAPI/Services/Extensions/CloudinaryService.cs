using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FahasaStoreAPI.Models.ViewModels;

namespace FahasaStoreAPI.Services.Extensions
{
    public interface ICloudinaryService
    {
        Task<CloudinaryVM> UploadImageAsync(IFormFile file, string? folderName);
        Task<bool> RemoveImageAsync(string? publicId);
    }
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(IConfiguration configuration)
        {
            var account = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]);
            _cloudinary = new Cloudinary(account);
        }
        public async Task<CloudinaryVM> UploadImageAsync(IFormFile file, string? folderName)
        {
            if (file == null || file.Length == 0)
            {
                var imageUploadResult = new CloudinaryVM("https://st.depositphotos.com/2934765/53192/v/450/depositphotos_531920820-stock-illustration-photo-available-vector-icon-default.jpg", null);
                return imageUploadResult;
            }

            using (var stream = file.OpenReadStream())
            {

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = !string.IsNullOrEmpty(folderName) ? folderName : null
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return new CloudinaryVM(uploadResult.Url.ToString(), uploadResult.PublicId);
            }
        }
        public async Task<bool> RemoveImageAsync(string? publicId)
        {
            if (string.IsNullOrWhiteSpace(publicId))
            {
                return false;
            }
            var deletionParams = new DeletionParams(publicId);
            var deletionResult = await _cloudinary.DestroyAsync(deletionParams);
            return deletionResult.Result == "ok";
        }

    }
}

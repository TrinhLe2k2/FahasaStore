namespace FahasaStoreAPI.Models.ViewModels
{
    public class CloudinaryVM
    {
        public CloudinaryVM(string imageUrl, string? publicId)
        {
            ImageUrl = imageUrl;
            PublicId = publicId;
        }

        public string ImageUrl { get; set; } = null!;
        public string? PublicId { get; set; }
    }
}

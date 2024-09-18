namespace FahasaStoreAPI.Models.DTOs
{
    public class CloudinaryDto
    {
        public CloudinaryDto(string imageUrl, string? publicId)
        {
            ImageUrl = imageUrl;
            PublicId = publicId;
        }

        public string ImageUrl { get; set; } = null!;
        public string? PublicId { get; set; }
    }
}

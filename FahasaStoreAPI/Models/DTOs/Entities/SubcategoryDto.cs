namespace FahasaStoreAPI.Models.DTOs.Entities
{
    public class SubcategoryCreateDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public IFormFile? image { get; set; }
    }
    public class SubcategoryEditDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public IFormFile? image { get; set; }
    }
}

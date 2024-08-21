namespace FahasaStoreAPI.Models.DTOs.Entities
{
    public class CategoryCreateDto
    {
        public string Name { get; set; } = null!;
        public IFormFile? image { get; set; }
    }
    public class CategoryEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IFormFile? image { get; set; }
    }
}

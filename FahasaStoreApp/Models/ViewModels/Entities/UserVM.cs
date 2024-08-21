namespace FahasaStoreApp.Models.ViewModels.Entities
{
    public class UserVM
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}

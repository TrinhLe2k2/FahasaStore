using Microsoft.AspNetCore.Identity;

namespace CreateDB.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

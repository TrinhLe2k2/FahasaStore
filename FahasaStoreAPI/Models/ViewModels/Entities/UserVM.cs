using FahasaStoreAPI.Models.Entities;

namespace FahasaStoreAPI.Models.ViewModels.Entities
{
    public class UserVM
    {
        public UserVM()
        {
            Addresses = new HashSet<Address>();
            Favourites = new HashSet<Favourite>();
            Notifications = new HashSet<Notification>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            Roles = new HashSet<AspNetRole>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public int CountAddresses { get; set; } = 0;
        public int CountFavourites { get; set; } = 0;
        public int CountNotifications { get; set; } = 0;
        public int CountOrders { get; set; } = 0;
        public int CountReviews { get; set; } = 0;

        public virtual Cart? Cart { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}

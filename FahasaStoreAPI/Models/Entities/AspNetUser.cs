using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class AspNetUser : IEntity<int>
    {
        public AspNetUser()
        {
            Addresses = new HashSet<Address>();
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
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
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}

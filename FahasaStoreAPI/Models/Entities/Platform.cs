using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Platform : IEntity<int>
    {
        public int Id { get; set; }
        public string PlatformName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Link { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}

using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Banner : IEntity<int>
    {
        public int Id { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}

using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Review : IEntity<int>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? OrderItemId { get; set; }
        public int? UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Book? Book { get; set; }
        public virtual OrderItem? OrderItem { get; set; }
        public virtual AspNetUser? User { get; set; }
    }
}

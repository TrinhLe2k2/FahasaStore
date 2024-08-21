using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Favourite : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}

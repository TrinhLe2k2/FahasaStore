using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class CartItem : IEntity<int>
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Cart Cart { get; set; } = null!;
    }
}

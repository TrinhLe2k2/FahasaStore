using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? OrderId { get; set; }
        public int? BookId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Order? Order { get; set; }
        public virtual AspNetUser? User { get; set; }
        public virtual Review? Review { get; set; }
    }
}

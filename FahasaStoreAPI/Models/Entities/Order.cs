using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            OrderStatuses = new HashSet<OrderStatus>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? VoucherId { get; set; }
        public int? AddressId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Address? Address { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public virtual AspNetUser? User { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

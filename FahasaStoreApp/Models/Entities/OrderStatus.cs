using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class OrderStatus
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Status? Status { get; set; }
    }
}

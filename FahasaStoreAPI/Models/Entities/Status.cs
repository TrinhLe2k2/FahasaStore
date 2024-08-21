using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Status : IEntity<int>
    {
        public Status()
        {
            OrderStatuses = new HashSet<OrderStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }
    }
}

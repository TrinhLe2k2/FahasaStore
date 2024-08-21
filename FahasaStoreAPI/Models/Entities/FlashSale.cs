using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class FlashSale : IEntity<int>
    {
        public FlashSale()
        {
            FlashSaleBooks = new HashSet<FlashSaleBook>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<FlashSaleBook> FlashSaleBooks { get; set; }
    }
}

using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Partner : IEntity<int>
    {
        public Partner()
        {
            BookPartners = new HashSet<BookPartner>();
        }

        public int Id { get; set; }
        public int PartnerTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual PartnerType PartnerType { get; set; } = null!;
        public virtual ICollection<BookPartner> BookPartners { get; set; }
    }
}

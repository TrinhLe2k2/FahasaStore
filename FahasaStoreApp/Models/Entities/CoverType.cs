using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class CoverType : IEntity<int>
    {
        public CoverType()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

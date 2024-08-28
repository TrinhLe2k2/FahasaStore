using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Favourite
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Book? Book { get; set; }
        public virtual AspNetUser? User { get; set; }
    }
}

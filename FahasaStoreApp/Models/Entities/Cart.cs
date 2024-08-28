﻿using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual AspNetUser? User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}

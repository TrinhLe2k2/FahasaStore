using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Notification : IEntity<int>
    {
        public int Id { get; set; }
        public int NotificationTypeId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual NotificationType NotificationType { get; set; } = null!;
        public virtual AspNetUser? User { get; set; }
    }
}

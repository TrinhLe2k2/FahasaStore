using FahasaStoreAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FahasaStoreAPI.Models.Entities
{
    public partial class Topic : IEntity<int>
    {
        public Topic()
        {
            TopicContents = new HashSet<TopicContent>();
        }

        public int Id { get; set; }
        public string TopicName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<TopicContent> TopicContents { get; set; }
    }
}

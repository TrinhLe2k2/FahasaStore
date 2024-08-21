namespace FahasaStoreAPI.Models.DTOs.Entities
{
    public class TopicDto
    {
        public int Id { get; set; }
        public string TopicName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}

namespace FahasaStoreAPI.Models.DTOs.Entities
{
    public class TopicContentDto
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}

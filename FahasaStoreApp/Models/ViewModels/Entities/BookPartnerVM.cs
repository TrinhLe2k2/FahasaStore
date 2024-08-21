namespace FahasaStoreApp.Models.ViewModels.Entities
{
    public class BookPartnerVM
    {
        public int PartnerId { get; set; } = 0;
        public string? PartnerName { get; set; }
        public int PartnerTypeId { get; set; } = 0;
        public string? PartnerType { get; set; }
    }
}

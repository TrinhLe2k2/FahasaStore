using X.PagedList;

namespace FahasaStoreApp.Models.ViewModels.Entities
{
    public class FlashSaleVM
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<FlashSaleBookVM>? FlashSaleBooks { get; set; }
    }
}

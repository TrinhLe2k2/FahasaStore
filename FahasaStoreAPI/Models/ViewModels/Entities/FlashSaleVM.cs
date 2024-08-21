using FahasaStoreAPI.Models.Entities;
using X.PagedList;

namespace FahasaStoreAPI.Models.ViewModels.Entities
{
    public class FlashSaleVM
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IPagedList<FlashSaleBookVM>? FlashSaleBooks { get; set; }
    }
}

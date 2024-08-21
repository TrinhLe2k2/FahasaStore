namespace FahasaStoreApp.Models.ViewModels.Entities
{
    public class FlashSaleBookVM
    {
        public int DiscountPercentage { get; set; }
        public int Quantity { get; set; }

        public int Solded { get; set; } = 0;
        public int PriceFS { get; set; } = 0;

        public virtual BookVM Book { get; set; } = null!;
    }
}

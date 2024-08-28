using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.Interfaces;

namespace FahasaStoreAPI.Models.ViewModels.Entities
{
    public class BookVM : IEntity<int>
    {
        public BookVM()
        {
            BookPartners = new HashSet<BookPartnerVM>();
            PosterImages = new HashSet<PosterImage>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int? SubcategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int? CoverTypeId { get; set; }
        public int? DimensionId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
        public int Quantity { get; set; }
        public double? Weight { get; set; }
        public int? PageCount { get; set; }
        public DateTime? CreatedAt { get; set; }

        public double RateAverage { get; set; } = 0;
        public int RateCount { get; set; } = 0;
        public int Solded { get; set; } = 0;
        public int CurrentPrice { get; set; } = 0;
        public int FavouritesCount { get; set; } = 0;

        public virtual Author? Author { get; set; }
        public virtual CoverType? CoverType { get; set; }
        public virtual Dimension? Dimension { get; set; }
        public virtual Subcategory? Subcategory { get; set; }
        public virtual ICollection<BookPartnerVM> BookPartners { get; set; }
        public virtual ICollection<PosterImage> PosterImages { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

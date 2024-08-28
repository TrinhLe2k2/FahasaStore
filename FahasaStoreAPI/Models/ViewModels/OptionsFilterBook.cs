using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;

namespace FahasaStoreAPI.Models.ViewModels
{
    public class DataOptionsFilterBook
    {
        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();
        public List<PartnerTypeVM> PartnerTypes { get; set; } = new List<PartnerTypeVM>();
        public List<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
        public List<CoverTypeDto> CoverTypes { get; set; } = new List<CoverTypeDto>();
        public List<DimensionDto> Dimensions { get; set; } = new List<DimensionDto>();
        public List<string> Price { get; set; } = new List<string> { "0 - 200000", "200000 - 400000", "400000 - 600000", "Trên 600,000đ" };
        public List<string> SortBy { get; set; } = new List<string> { "CurrentPrice", "CreatedAt", "Name" };
    }

    public class OptionsFilterBook
    {
        public string? SearchName { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int? PartnerTypeId { get; set; }
        public int? PartnerId { get; set; }
        public int? CoverTypeId { get; set; }
        public int? DimensionId { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }


        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;

        public string? SortBy { get; set; }
        public bool SortDescending { get; set; } = false;
    }

    public class ResultFilterBook
    {
        public OptionsFilterBook optionsFilterBook { get; set; } = new OptionsFilterBook();
        public PagedVM<BookDto> books { get; set; } = new PagedVM<BookDto>();
    }
}


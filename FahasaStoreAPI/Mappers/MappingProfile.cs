using AutoMapper;
using FahasaStoreAPI.Controllers;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;

namespace FahasaStoreAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Subcategory, SubcategoryCreateDto>().ReverseMap();
            CreateMap<Subcategory, SubcategoryEditDto>().ReverseMap();

            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookEditDto>().ReverseMap();

            CreateMap<Category, CategoryVM>()
            .ForMember(dest => dest.CountSubcategories, opt => opt.MapFrom(src => src.Subcategories.Count))
            .ForMember(dest => dest.Subcategories, opt => opt.MapFrom(src => src.Subcategories
                .OrderByDescending(s => s.CreatedAt)
                .Take(2)
            ));

            CreateMap<Book, BookVM>()
            .ForMember(dest => dest.RateAverage, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0))
            .ForMember(dest => dest.RateCount, opt => opt.MapFrom(src => src.Reviews.Count))
            .ForMember(dest => dest.Solded, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.Quantity)))
            .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(src => src.Price - (src.Price * src.DiscountPercentage / 100)))
            .ForMember(dest => dest.FavouritesCount, opt => opt.MapFrom(src => src.Favourites.Count))
            .ForMember(dest => dest.BookPartners, opt => opt.MapFrom(src => src.BookPartners.Select(bp => new BookPartnerVM
            {
                PartnerId = bp.PartnerId,
                PartnerName = bp.Partner.Name,
                PartnerTypeId = bp.Partner.PartnerTypeId,
                PartnerType = bp.Partner.PartnerType.Name
            })))
            .ForMember(dest => dest.PosterImages, opt => opt.MapFrom(src => src.PosterImages.OrderByDescending(p => p.CreatedAt).Take(1)))
            .ReverseMap();
        }
    }
}

using AutoMapper;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Models.DTOs.Entities;

namespace FahasaStoreApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Subcategory, SubcategoryCreateDto>().ReverseMap();
            CreateMap<Subcategory, SubcategoryEditDto>().ReverseMap();
        }
    }
}

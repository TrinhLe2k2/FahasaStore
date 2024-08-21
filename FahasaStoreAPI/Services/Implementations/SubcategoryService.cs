using AutoMapper;
using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Repositories.Interfaces;
using FahasaStoreAPI.Services.Interfaces;

namespace FahasaStoreAPI.Services.Implementations
{
    public class SubcategoryService : BaseService<Subcategory, SubcategoryDto, int>, ISubcategoryService
    {
        public SubcategoryService(ISubcategoryRepository repository, IMapper mapper, ICloudinaryService cloudinaryService) : base(repository, mapper, cloudinaryService)
        {
        }
    }
}

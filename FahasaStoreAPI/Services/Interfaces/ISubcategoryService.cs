using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;

namespace FahasaStoreAPI.Services.Interfaces
{
    public interface ISubcategoryService : IBaseService<Subcategory, SubcategoryDto, int>
    {
    }
}

using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : BaseController<Subcategory, SubcategoryCreateDto , CategoryEditDto, int>
    {
        public SubcategoriesController(IBaseService<Subcategory, SubcategoryCreateDto , CategoryEditDto, int> service) : base(service)
        {
        } 
    }
}

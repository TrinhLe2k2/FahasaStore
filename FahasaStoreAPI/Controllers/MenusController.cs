using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;
using Microsoft.AspNetCore.Mvc;


namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController<Menu, MenuVM>
    {
        public MenuController(IBaseService<Menu, MenuVM> service) : base(service)
        {
        }
    }
}

using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : BaseController<Menu, Menu, Menu, int>
    {
        public MenusController(IBaseService<Menu, Menu, Menu, int> service) : base(service)
        {
        }
    }
}

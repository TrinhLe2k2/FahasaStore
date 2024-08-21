using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : BaseController<Banner, Banner, Banner, int>
    {
        public BannersController(IBaseService<Banner, Banner, Banner, int> service) : base(service)
        {
        }
    }
}

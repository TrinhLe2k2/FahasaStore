using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : BaseController<Platform, Platform, Platform, int>
    {
        public PlatformsController(IBaseService<Platform, Platform, Platform, int> service) : base(service)
        {
        }
    }
}

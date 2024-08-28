using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : BaseController<Platform, PlatformVM>
    {
        public PlatformController(IBaseService<Platform, PlatformVM> service) : base(service)
        {
        }
    }
}

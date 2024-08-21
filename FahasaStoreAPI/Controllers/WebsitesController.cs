using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsitesController : BaseController<Website, Website, Website, int>
    {
        public WebsitesController(IBaseService<Website, Website, Website, int> service) : base(service)
        {
        }
    }
}

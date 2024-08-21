using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : BaseController<Partner, Partner, Partner, int>
    {
        public PartnersController(IBaseService<Partner, Partner, Partner, int> service) : base(service)
        {
        }
    }
}

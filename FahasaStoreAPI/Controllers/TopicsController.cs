using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : BaseController<Topic, Topic, Topic, int>
    {
        public TopicsController(IBaseService<Topic, Topic, Topic, int> service) : base(service)
        {
        }
    }
}

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
    public class TopicContentsController : BaseController<TopicContent, TopicContent, TopicContent, int>
    {
        public TopicContentsController(IBaseService<TopicContent, TopicContent, TopicContent, int> service) : base(service)
        {
        }
    }
}

using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashSalesController : BaseController<FlashSale, FlashSale, FlashSale, int>
    {
        public FlashSalesController(IBaseService<FlashSale, FlashSale, FlashSale, int> service) : base(service)
        {
        }
    }
}

using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashSaleController : BaseController<FlashSale, FlashSaleVM>
    {
        public FlashSaleController(IBaseService<FlashSale, FlashSaleVM> service) : base(service)
        {
        }
    }
}

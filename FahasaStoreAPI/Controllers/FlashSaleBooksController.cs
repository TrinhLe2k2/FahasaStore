using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashSaleBookController : BaseController<FlashSaleBook, FlashSaleBookVM>
    {
        public FlashSaleBookController(IBaseService<FlashSaleBook, FlashSaleBookVM> service) : base(service)
        {
        }
    }
}

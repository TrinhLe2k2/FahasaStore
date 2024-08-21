using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashSaleBooksController : BaseController<FlashSaleBook, FlashSaleBook, FlashSaleBook, int>
    {
        public FlashSaleBooksController(IBaseService<FlashSaleBook, FlashSaleBook, FlashSaleBook, int> service) : base(service)
        {
        }
    }
}

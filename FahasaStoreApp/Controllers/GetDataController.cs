using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Controllers
{
    public class GetDataController : Controller
    {
        private readonly IFahasaStoreService _fahasaStoreService;

        public GetDataController(IFahasaStoreService fahasaStoreService)
        {
            _fahasaStoreService = fahasaStoreService;
        }

        [HttpGet]
        public async Task<IActionResult> TopSellingBooksByCategory(int id)
        {
            var topSellingBooksByCategory = await _fahasaStoreService.TopSellingBooksByCategory(id, 1, 5);
            ViewData["TopSellingBooksByCategory"] = topSellingBooksByCategory.Items;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> FilterBook(OptionsFilterBook optionsFilterBook)
        {
            var resultFilter = await _fahasaStoreService.FilterBook(optionsFilterBook);
            return PartialView(resultFilter);
        }
    }
}

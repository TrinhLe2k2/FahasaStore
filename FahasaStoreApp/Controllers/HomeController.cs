using FahasaStoreApp.Constants;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FahasaStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFahasaStoreService _fahasaStoreService;

        public HomeController(IFahasaStoreService fahasaStoreService)
        {
            _fahasaStoreService = fahasaStoreService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _fahasaStoreService.DataForHomeIndex(15, 20, 50, 10, 10, 5, 30);
            ViewData["Data"] = data;
            return View();
        }

        public async Task<IActionResult> Product(int id)
        {
            var dataProduct = await _fahasaStoreService.DataForHomeProduct(id);
            ViewData["DataProduct"] = dataProduct;
            return View();
        }

        public async Task<IActionResult> Filter(OptionsFilterBook optionsFilterBook)
        {
            var dataOptionsFilterBook = await _fahasaStoreService.DataOptionsFilterBook();
            ViewData["DataOptionsFilterBook"] = dataOptionsFilterBook;
            var resultFilter = await _fahasaStoreService.FilterBook(optionsFilterBook);
            ViewData["ResultFilter"] = resultFilter;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }
    }
}

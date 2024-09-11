using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Controllers
{
    public class GetDataController : Controller
    {
        private readonly IFahasaStoreService _fahasaStoreService;
        private readonly IViettelPostService _viettelPostService;

        public GetDataController(IFahasaStoreService fahasaStoreService, IViettelPostService viettelPostService)
        {
            _fahasaStoreService = fahasaStoreService;
            _viettelPostService = viettelPostService;
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

        [HttpGet]
        public async Task<IActionResult> ProductReviews(int bookId, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.ProductReviews(bookId, pageNumber, pageSize);
            return PartialView(result);
        }

        [HttpGet]
        public async Task<IActionResult> OnGetProvinces(string? province)
        {
            var provinces = await _viettelPostService.GetListProvince();
            ViewData["Province"] = province;
            return PartialView(provinces);
        }

        [HttpGet]
        public async Task<IActionResult> OnGetDistricts(string? district, int provinceId)
        {
            var districts = await _viettelPostService.GetListDistrictByProvinceId(provinceId);
            ViewData["District"] = district;
            return PartialView(districts);
        }

        [HttpGet]
        public async Task<IActionResult> OnGetWards(string? ward, int districtId)
        {
            var wards = await _viettelPostService.GetListWardByDistrictId(districtId);
            ViewData["Ward"] = ward;
            return PartialView(wards);
        }
    }
}

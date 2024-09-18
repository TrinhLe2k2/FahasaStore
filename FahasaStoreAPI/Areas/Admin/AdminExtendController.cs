using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AppRole.Admin)]
    public class AdminExtendController : ControllerBase
    {
        private readonly IAdminExtendService _adminExtendService;

        public AdminExtendController(IAdminExtendService adminExtendService)
        {
            _adminExtendService = adminExtendService;
        }
        [HttpGet("GetYearlyStatistics")]
        public async Task<ActionResult> GetYearlyStatistics(int? year)
        {
            var result = await _adminExtendService.GetYearlyStatisticsAsync(year);
            return Ok(result);
        }
    }
}

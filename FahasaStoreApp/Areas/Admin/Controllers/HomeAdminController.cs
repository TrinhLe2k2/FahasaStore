using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

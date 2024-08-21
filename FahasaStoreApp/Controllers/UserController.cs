using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace eShowroom.Controllers
{
    public class AdminsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Statistique()
        {
            return View();
        }
    }
}

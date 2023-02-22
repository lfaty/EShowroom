using eShowroom.Data.Services;
using eShowroom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eShowroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService _service;

        public HomeController(ILogger<HomeController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(p => p.Category);
            return View(allProducts);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var productsDetails = await _service.GetByIdAsync(id);
            if (productsDetails == null) return View("NotFound");

            return View(productsDetails);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
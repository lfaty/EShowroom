using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eShowroom.Data;
using eShowroom.Models;
using eShowroom.Data.Services;
using System.Numerics;

namespace eShowroom.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _service;

        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var allCategories = await _service.GetAllAsync();
            return View(allCategories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var categoriesDetails = await _service.GetByIdAsync(id);
            if (categoriesDetails == null) return View("NotFound");

            return View(categoriesDetails);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName,EnteredDate")] Category category)
        {
            if (category == null)
            {
                return View(category);
            }
            category.EnteredDate = DateTime.Now;
            await _service.AddAsync(category);
            return RedirectToAction(nameof(Index));

        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var categoriesDetails = await _service.GetByIdAsync(id);
            if (categoriesDetails == null) return View("NotFound");
            return View(categoriesDetails);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,EnteredDate")] Category category)
        {
            if (category == null)
            {
                return View(category);
            }
            category.EnteredDate = DateTime.Now;
            await _service.UpdateAsync(id, category);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var categoriesDetails = await _service.GetByIdAsync(id);
            if (categoriesDetails == null) return View("NotFound");
            return View(categoriesDetails);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriesDetails = await _service.GetByIdAsync(id);
            if (categoriesDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

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

namespace eShowroom.Controllers
{
    public class ApprovisonnementsController : Controller
    {
        private readonly IApprovisionnementsService _service;

        public ApprovisonnementsController(IApprovisionnementsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> TableauAppro()
        {
            return View();
        }

        // GET: Approvisonnements
        public async Task<IActionResult> Index()
        {
            var allApprovisionnements = await _service.GetAllAsync(f => f.Product);
            return View(allApprovisionnements);
        }

        // GET: Approvisonnements/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var approvisionnementsDetails = await _service.GetByIdAsync(id);
            if (approvisionnementsDetails == null) return View("NotFound");

            return View(approvisionnementsDetails);
        }

        // GET: Approvisonnements/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["BonEntreeId"] = new SelectList(_context.BonEntrees, "Id", "Id");
            var productDropdownsData = await _service.GetProductDropdownValues();
            ViewData["ProductId"] = new SelectList(productDropdownsData.Products, "Id", "ProductName");

            return View();
        }

        // POST: Approvisonnements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,NormalePrice,EnteredDate,ProductId,BonEntreeId")] Approvisonnement approvisonnement)
        {
            if (ModelState.Count > 0)
            {
                approvisonnement.EnteredDate = DateTime.Now;
                await _service.AddAsync(approvisonnement);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["BonEntreeId"] = new SelectList(_context.BonEntrees, "Id", "Id");
            var productDropdownsData = await _service.GetProductDropdownValues();
            ViewData["ProductId"] = new SelectList(productDropdownsData.Products, "Id", "ProductName");

            return View(approvisonnement);
        }

        // GET: Approvisonnements/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //ViewData["BonEntreeId"] = new SelectList(_context.BonEntrees, "Id", "Id");
            var productDropdownsData = await _service.GetProductDropdownValues();
            ViewData["ProductId"] = new SelectList(productDropdownsData.Products, "Id", "ProductName");

            var approvisionnementsDetails = await _service.GetByIdAsync(id);
            if (approvisionnementsDetails == null) return View("NotFound");

            return View(approvisionnementsDetails);
        }

        // POST: Approvisonnements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,NormalePrice,EnteredDate,ProductId,BonEntreeId")] Approvisonnement approvisonnement)
        {
            if (ModelState.Count > 0)
            {
                approvisonnement.EnteredDate = DateTime.Now;
                await _service.UpdateAsync(id, approvisonnement);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["BonEntreeId"] = new SelectList(_context.BonEntrees, "Id", "Id");
            var productDropdownsData = await _service.GetProductDropdownValues();
            ViewData["ProductId"] = new SelectList(productDropdownsData.Products, "Id", "ProductName");

            return View(approvisonnement);
        }

        // GET: Approvisonnements/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var approvisionnementsDetails = await _service.GetByIdAsync(id);
            if (approvisionnementsDetails == null) return View("NotFound");

            return View(approvisionnementsDetails);
        }

        // POST: Approvisonnements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approvisionnementDetails = await _service.GetByIdAsync(id);
            if (approvisionnementDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

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
    public class BonEntreesController : Controller
    {
        private readonly IBonEntreesService _service;

        public BonEntreesController(IBonEntreesService service)
        {
            _service = service;
        }

        // GET: BonEntrees
        public async Task<IActionResult> Index()
        {
            var allBonEntrees = await _service.GetAllAsync(f => f.Fournisseur);
            return View(allBonEntrees);
        }

        // GET: BonEntrees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var bonsDetails = await _service.GetByIdAsync(id);
            if (bonsDetails == null) return View("NotFound");

            return View(bonsDetails);
        }

        // GET: BonEntrees/Create
        public async Task<IActionResult> Create()
        {
            var fournisseurDropdownsData = await _service.GetFournisseurDropdownValues();
            ViewData["FournisseurId"] = new SelectList(fournisseurDropdownsData.Fournisseurs, "Id", "FournisseurName");

            return View();
        }

        // POST: BonEntrees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroBon,DateBon,EnteredDate,FournisseurId")] BonEntree bonEntree)
        {
            if (ModelState.Count > 0)
            {
                bonEntree.EnteredDate = DateTime.Now;
                await _service.AddAsync(bonEntree);
                return RedirectToAction(nameof(Index));
            }
            var fournisseurDropdownsData = await _service.GetFournisseurDropdownValues();
            ViewData["FournisseurId"] = new SelectList(fournisseurDropdownsData.Fournisseurs, "Id", "FournisseurName");

            return View(bonEntree);
        }

        // GET: BonEntrees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var fournisseurDropdownsData = await _service.GetFournisseurDropdownValues();
            ViewData["FournisseurId"] = new SelectList(fournisseurDropdownsData.Fournisseurs, "Id", "FournisseurName");

            var bonsDetails = await _service.GetByIdAsync(id);
            if (bonsDetails == null) return View("NotFound");

            return View(bonsDetails);
        }

        // POST: BonEntrees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroBon,DateBon,EnteredDate,FournisseurId")] BonEntree bonEntree)
        {
            if (ModelState.Count > 0)
            {
                bonEntree.EnteredDate = DateTime.Now;
                await _service.UpdateAsync(id, bonEntree);
                return RedirectToAction(nameof(Index));
            }
            var fournisseurDropdownsData = await _service.GetFournisseurDropdownValues();
            ViewData["FournisseurId"] = new SelectList(fournisseurDropdownsData.Fournisseurs, "Id", "FournisseurName");

            return View(bonEntree);
        }

        // GET: BonEntrees/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var bonsDetails = await _service.GetByIdAsync(id);
            if (bonsDetails == null) return View("NotFound");

            return View(bonsDetails);
        }

        // POST: BonEntrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bonsDetails = await _service.GetByIdAsync(id);
            if (bonsDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

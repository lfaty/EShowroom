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
    public class FournisseursController : Controller
    {
        private readonly IFournisseursService _service;

        public FournisseursController(IFournisseursService service)
        {
            _service = service;
        }

        // GET: Fournisseurs
        public async Task<IActionResult> Index()
        {
            var allFournisseur = await _service.GetAllAsync();
            return View(allFournisseur);
        }

        // GET: Fournisseurs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var fournisseursDetails = await _service.GetByIdAsync(id);
            if (fournisseursDetails == null) return View("NotFound");

            return View(fournisseursDetails);
        }

        // GET: Fournisseurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fournisseurs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FournisseurName,SiegeSocial,Logo,UrlLogo,FournisseurAdresse,FournisseurEmail,FournisseurTel,FournissuerSlogan,EnteredDate")] Fournisseur fournisseur)
        {

            if (ModelState.Count == 0)
            {
                return View(fournisseur);
            }
            fournisseur.EnteredDate = DateTime.Now;
            await _service.AddAsync(fournisseur);
            return RedirectToAction(nameof(Index));
        }

        // GET: Fournisseurs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var fournisseursDetails = await _service.GetByIdAsync(id);
            if (fournisseursDetails == null) return View("NotFound");

            return View(fournisseursDetails);
        }

        // POST: Fournisseurs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FournisseurName,SiegeSocial,Logo,UrlLogo,FournisseurAdresse,FournisseurEmail,FournisseurTel,FournissuerSlogan,EnteredDate")] Fournisseur fournisseur)
        {
            if (ModelState.Count == 0)
            {
                return View(fournisseur);
            }
            fournisseur.EnteredDate = DateTime.Now;
            await _service.UpdateAsync(id, fournisseur);
            return RedirectToAction(nameof(Index));
        }

        // GET: Fournisseurs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var fournisseursDetails = await _service.GetByIdAsync(id);
            if (fournisseursDetails == null) return View("NotFound");

            return View(fournisseursDetails);
        }

        // POST: Fournisseurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fournisseursDetails = await _service.GetByIdAsync(id);
            if (fournisseursDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

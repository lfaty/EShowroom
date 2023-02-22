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
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        private readonly IWebHostEnvironment _env;

        public ProductsController(IProductsService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(f => f.Category);
            return View(allProducts);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var productsDetails = await _service.GetByIdAsync(id);
            if (productsDetails == null) return View("NotFound");

            return View(productsDetails);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetCategoryDropdownValues();

            ViewData["CategoryId"] = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");
            //ViewBag.Personnels = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,ProductShortDesc,ProductLongDesc,ProductStock,ProductImage,ProductUrlImage,EnteredDate,CategoryId")] Product product)
        {
            if (ModelState.Count > 0)
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0]; // le nom de notre fichier
                    if (file != null && file.Length > 0)
                    {
                        var imagePath = @"\Images\Products\";
                        var uploadPath = _env.WebRootPath + imagePath;

                        //Create Directory
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(uploadPath, fileName);

                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStrem);
                        }
                        product.ProductImage = fileName;
                        product.ProductUrlImage = "/Images/Products";
                    }
                }
                product.EnteredDate = DateTime.Now;
                await _service.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            var productDropdownsData = await _service.GetCategoryDropdownValues();
            ViewData["CategoryId"] = new SelectList(productDropdownsData.Categories, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }
        
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var productDropdownsData = await _service.GetCategoryDropdownValues();
            ViewData["CategoryId"] = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");

            var productsDetails = await _service.GetByIdAsync(id);
            if (productsDetails == null) return View("NotFound");

            return View(productsDetails);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,ProductShortDesc,ProductLongDesc,ProductStock,ProductImage,ProductUrlImage,EnteredDate,CategoryId")] Product product)
        {

            if (ModelState.Count > 0)
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0]; // le nom de notre fichier
                    if (file != null && file.Length > 0)
                    {
                        var imagePath = @"\Images\Products\";
                        var uploadPath = _env.WebRootPath + imagePath;

                        //Create Directory
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(uploadPath, fileName);

                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStrem);
                        }
                        product.ProductImage = fileName;
                        product.ProductUrlImage = "/Images/Products";
                    }
                }
                product.EnteredDate = DateTime.Now;
                await _service.UpdateAsync(id, product);
                return RedirectToAction(nameof(Index));
            }
            var productDropdownsData = await _service.GetCategoryDropdownValues();
            ViewData["CategoryId"] = new SelectList(productDropdownsData.Categories, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var productsDetails = await _service.GetByIdAsync(id);
            if (productsDetails == null) return View("NotFound");

            return View(productsDetails);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productsDetails = await _service.GetByIdAsync(id);
            if (productsDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}

using eShowroom.Data.Base;
using eShowroom.Data.ViewModels;
using eShowroom.Models;
using Microsoft.EntityFrameworkCore;

namespace eShowroom.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CategoryDropdownsVM> GetCategoryDropdownValues()
        {
            var response = new CategoryDropdownsVM()
            {
               Categories = await _context.Categories.OrderBy(n => n.CategoryName).ToListAsync()
            };

            return response;
        }
    }
}

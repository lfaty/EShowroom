using eShowroom.Data.Base;
using eShowroom.Data.ViewModels;
using eShowroom.Models;
using Microsoft.EntityFrameworkCore;

namespace eShowroom.Data.Services
{
    public class ApprovisionnementsService : EntityBaseRepository<Approvisonnement>, IApprovisionnementsService
    {
        private readonly AppDbContext _context;

        public ApprovisionnementsService(AppDbContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<ProductDropdownsVM> GetProductDropdownValues()
        {
            var response = new ProductDropdownsVM()
            {
                Products = await _context.Products.OrderBy(n => n.ProductName).ToListAsync()
            };

            return response;
        }
    }
}

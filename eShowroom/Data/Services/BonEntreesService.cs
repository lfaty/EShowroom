using eShowroom.Data.Base;
using eShowroom.Data.ViewModels;
using eShowroom.Models;
using Microsoft.EntityFrameworkCore;

namespace eShowroom.Data.Services
{
    public class BonEntreesService : EntityBaseRepository<BonEntree>, IBonEntreesService
    {
        private readonly AppDbContext _context;

        public BonEntreesService(AppDbContext context) : base(context)
        {
            _context= context;
        }

        public async Task<FournisseurDropdownsVM> GetFournisseurDropdownValues()
        {
            var response = new FournisseurDropdownsVM()
            {
                Fournisseurs = await _context.Fournisseurs.OrderBy(n => n.FournisseurName).ToListAsync()
            };

            return response;
        }
    }
}

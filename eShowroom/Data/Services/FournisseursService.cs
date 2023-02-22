using eShowroom.Data.Base;
using eShowroom.Models;

namespace eShowroom.Data.Services
{
    public class FournisseursService : EntityBaseRepository<Fournisseur>, IFournisseursService
    {
        public FournisseursService(AppDbContext context) : base(context)
        {
        }
    }
}

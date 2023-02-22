using eShowroom.Data.Base;
using eShowroom.Data.ViewModels;
using eShowroom.Models;

namespace eShowroom.Data.Services
{
    public interface IBonEntreesService: IEntityBaseRepository<BonEntree>
    {
        Task<FournisseurDropdownsVM> GetFournisseurDropdownValues();
    }
}

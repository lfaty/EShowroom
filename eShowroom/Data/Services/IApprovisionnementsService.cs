using eShowroom.Data.Base;
using eShowroom.Data.ViewModels;
using eShowroom.Models;

namespace eShowroom.Data.Services
{
    public interface IApprovisionnementsService: IEntityBaseRepository<Approvisonnement>
    {
        Task<ProductDropdownsVM> GetProductDropdownValues();
    }
}

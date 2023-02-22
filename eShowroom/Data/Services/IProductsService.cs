using eShowroom.Data.Base;
using eShowroom.Data.ViewModels;
using eShowroom.Models;
using System.Threading.Tasks;

namespace eShowroom.Data.Services
{
    public interface IProductsService: IEntityBaseRepository<Product>
    {
        Task<CategoryDropdownsVM> GetCategoryDropdownValues();
    }
}

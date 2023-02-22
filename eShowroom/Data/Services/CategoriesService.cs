using eShowroom.Data.Base;
using eShowroom.Models;

namespace eShowroom.Data.Services
{
    public class CategoriesService : EntityBaseRepository<Category>, ICategoriesService
    {
        public CategoriesService(AppDbContext context) : base(context)
        {
        }
    }
}

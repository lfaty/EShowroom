using eShowroom.Models;

namespace eShowroom.Data.ViewModels
{
    public class CategoryDropdownsVM
    {
        public CategoryDropdownsVM()
        {
            Categories = new List<Category>();
        }

        public List<Category> Categories { get; set; }
    }
}

using eShowroom.Models;

namespace eShowroom.Data.ViewModels
{
    public class ProductDropdownsVM
    {
        public ProductDropdownsVM()
        {
            Products = new List<Product>();
        }

        public List<Product> Products { get; set; }
    }
}

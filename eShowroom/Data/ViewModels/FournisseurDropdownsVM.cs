using eShowroom.Models;

namespace eShowroom.Data.ViewModels
{
    public class FournisseurDropdownsVM
    {
        public FournisseurDropdownsVM()
        {
            Fournisseurs = new List<Fournisseur>();
        }

        public List<Fournisseur> Fournisseurs { get; set; }
    }
}

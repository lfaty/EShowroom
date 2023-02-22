
using eShowroom.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShowroom.Models
{

    public class Product:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Libellé")]
        [Required(ErrorMessage = "Nom du produit est obligatoire")]
        public string ProductName { get; set; }

        [Display(Name = "Courte description")]
        [Required(ErrorMessage = "Cette desciption du produit est obligatoire")]
        public string ProductShortDesc { get; set; }

        [Display(Name = "Longue description")]
        public string ProductLongDesc { get; set; }

        public int ProductStock { get; set; }

        [Display(Name = "Image")]
        public string ProductImage { get; set; }

        public string ProductUrlImage { get; set; }

        public DateTime EnteredDate { get; set; }

        //Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public List<Approvisonnement> Approvisonnements { get; set; }

    }
}

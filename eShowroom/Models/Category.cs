
using eShowroom.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eShowroom.Models
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Catégorie")]
        [Required]
        public string? CategoryName { get; set; }

        [Display(Name = "Date saisie")]
        public DateTime? EnteredDate { get; set; }

        //Relationships
        public List<Product> Products { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using eShowroom.Data.Base;

namespace eShowroom.Models
{
    public class Approvisonnement : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double NormalePrice { get; set; }

        public DateTime EnteredDate { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int BonEntreeId { get; set; }
        [ForeignKey("BonEntreeId")]
        public BonEntree BonEntree { get; set; }
    }
}

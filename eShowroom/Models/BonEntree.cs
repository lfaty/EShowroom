using eShowroom.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShowroom.Models
{
    public class BonEntree : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int NumeroBon { get; set; }
        public DateTime DateBon { get; set; }
        public DateTime EnteredDate { get; set; }

        //Fournisseur
        public int FournisseurId { get; set; }
        [ForeignKey("FournisseurId")]
        public Fournisseur Fournisseur { get; set; }

        public List<Approvisonnement> Approvisonnements { get; set; }

    }
}

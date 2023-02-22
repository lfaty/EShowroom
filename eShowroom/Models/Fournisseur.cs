using eShowroom.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eShowroom.Models
{
    public class Fournisseur : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string FournisseurName { get; set; }
        public string SiegeSocial { get; set; }
        public string Logo { get; set; }
        public string UrlLogo { get; set; }
        public string FournisseurAdresse { get; set; }
        public string FournisseurEmail { get; set; }
        public string FournisseurTel { get; set; }
        public string FournissuerSlogan { get; set; }

        public DateTime EnteredDate { get; set; }

        public List<BonEntree> BonEntrees { get; set; }

    }
}

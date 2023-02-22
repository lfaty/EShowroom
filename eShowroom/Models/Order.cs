using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eShowroom.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string OrderCode { get; set; }

        public DateTime EnteredDate { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
       public ApplicationUser User { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}

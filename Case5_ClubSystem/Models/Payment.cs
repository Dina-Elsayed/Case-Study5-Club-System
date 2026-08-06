using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case5_ClubSystem.Models
{
    public class Payment
    {

        public int Id { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required, Range(100.00, 10000.00)]
        public decimal Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [ForeignKey(nameof(Membership))]
        public int MembershipId { get; set; }
        public Membership Membership { get; set; }

    }
}

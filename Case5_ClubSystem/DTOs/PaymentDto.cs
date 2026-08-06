using System.ComponentModel.DataAnnotations;

namespace Case5_ClubSystem.DTOs
{
    public class PaymentDto
    {

        [Required, Range(100.00, 10000.00)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        public int MembershipId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case5_ClubSystem.Models
{
    public class Membership
    {
        public int Id { get; set; }

        [Required]
        public  string Type { get; set; }

        [Required]
        public DateTime StartDate { get; set; }


        [Required]
     
        public DateTime EndDate { get; set; }


        [Required, Range(100.0, 10000.0)]
        public decimal Price { get; set; }

        [Required]
        public string Status { get; set; }


        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public ICollection<Payment> Payments { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace Case5_ClubSystem.DTOs
{
    public class MembershipDto
    {

        [Required]
        public string Type { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required, Range(100.0, 10000.0)]
        public decimal Price { get; set; }

        [Required]
        public string Status { get; set; }

        public int MemberId { get; set; }
    }
}

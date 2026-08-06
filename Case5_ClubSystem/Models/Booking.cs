using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case5_ClubSystem.Models
{
    public class Booking
    {

        public int Id { get; set; }
      
        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }

        [Required,Range(1,100)]
        public int GroupSize { get; set; }

        [Required]
        public string Status { get; set; }

        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }

        public Member Member { get; set; }

        [ForeignKey(nameof(Facility))]
        public int FacilityId { get; set; }

        public Facility Facility { get; set; }
    }
}

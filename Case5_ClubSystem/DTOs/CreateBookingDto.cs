using System.ComponentModel.DataAnnotations;

namespace Case5_ClubSystem.DTOs
{
    public class CreateBookingDto
    {
       

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Range(1, 100)]
        public int GroupSize { get; set; }

        public int MemberId { get; set; }

        public int FacilityId { get; set; }
    }
}

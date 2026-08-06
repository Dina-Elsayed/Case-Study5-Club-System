using System.ComponentModel.DataAnnotations;

namespace Case5_ClubSystem.DTOs
{
    public class UpdateBookingDto
    {
        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Range(1, 100)]
        public int GroupSize { get; set; }

        [Required]
        public string Status { get; set; }
    }
}

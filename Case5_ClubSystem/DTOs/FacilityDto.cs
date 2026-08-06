using System.ComponentModel.DataAnnotations;

namespace Case5_ClubSystem.DTOs
{
    public class FacilityDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Capacity { get; set; }

        [Range(50, 10000)]
        public decimal HourlyPrice { get; set; }
    }
}

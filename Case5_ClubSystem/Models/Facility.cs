using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Case5_ClubSystem.Models
{

    [Index(nameof(Name), IsUnique =true)]
    public class Facility
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }


        [Required,Range(1,100)]
        public int Capacity { get; set; }


        [Required,Range(50, 10000)]
        public decimal HourlyPrice { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}

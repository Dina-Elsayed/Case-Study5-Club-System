using System.ComponentModel.DataAnnotations;

namespace Case5_ClubSystem.Models
{
    public class Member
    {

        public int Id { get; set; }

        [Required,MinLength(3),MaxLength(100)]
        public string FullName { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required,Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public Membership Membership { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}

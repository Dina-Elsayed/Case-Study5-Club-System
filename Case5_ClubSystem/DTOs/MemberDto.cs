using System.ComponentModel.DataAnnotations;

namespace Case5_ClubSystem.DTOs
{
    public class MemberDto
    {
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}

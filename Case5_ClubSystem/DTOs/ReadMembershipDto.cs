namespace Case5_ClubSystem.DTOs
{
    public class ReadMembershipDto
    {

        public int Id { get; set; }

        public string Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public string MemberName { get; set; }

    }
}

namespace Case5_ClubSystem.DTOs
{
    public class ReadBookingDto
    {
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int GroupSize { get; set; }

        public string Status { get; set; }

        public string MemberName { get; set; }

        public string FacilityName { get; set; }
    }
}

namespace Case5_ClubSystem.DTOs
{
    public class ReadPaymentDto
    {


        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }

        public int MembershipId { get; set; }
    }
}

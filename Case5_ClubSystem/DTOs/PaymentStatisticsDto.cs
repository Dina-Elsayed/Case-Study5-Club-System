namespace Case5_ClubSystem.DTOs
{
    public class PaymentStatisticsDto
    {


        public decimal TotalRevenue { get; set; }

        public decimal AveragePayment { get; set; }

        public decimal HighestPayment { get; set; }

        public decimal LowestPayment { get; set; }

        public int TotalPayments { get; set; }
    }
}

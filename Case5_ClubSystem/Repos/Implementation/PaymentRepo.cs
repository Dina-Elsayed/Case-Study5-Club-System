using Case5_ClubSystem.AppDbContext;
using Case5_ClubSystem.DTOs;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case5_ClubSystem.Repos.Implementation
{
    public class PaymentRepo : GenericRepo<Payment>, IPaymentRepository
    {

        private readonly ClubDbContext _context;

        public PaymentRepo(ClubDbContext context) : base(context)
        {

            _context = context;
        }


        public async Task<PaymentStatisticsDto> GetStatisticsAsync()
        {
            return new PaymentStatisticsDto
            {
                TotalRevenue = await _context.Payments.SumAsync(p => p.Amount),
                AveragePayment = await _context.Payments.AverageAsync(p => p.Amount),
                HighestPayment = await _context.Payments.MaxAsync(p => p.Amount),
                LowestPayment = await _context.Payments.MinAsync(p => p.Amount),
                TotalPayments = await _context.Payments.CountAsync()
            };
        }

    }
}

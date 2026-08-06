using Case5_ClubSystem.Repos.Interface;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.DTOs;

namespace Case5_ClubSystem.Repos.Interface
{
    public interface IPaymentRepository : IGenericRepo<Payment>
    {
        Task<PaymentStatisticsDto> GetStatisticsAsync();
    }
}

using Case5_ClubSystem.Repos.Interface;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.DTOs;

namespace Case5_ClubSystem.Repos.Interface
{
    public interface IBookingRepository : IGenericRepo<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsAsync(
        int pageNumber,
        int pageSize,
        string? status,
        int? facilityId);

        Task<IEnumerable<BookingReportDto>> GetBookingReportAsync();

        Task CancelBookingAsync(int id);

        Task<Booking?> GetBookingByIdAsync(int id);
    }
}

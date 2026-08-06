using Case5_ClubSystem.AppDbContext;
using Case5_ClubSystem.DTOs;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case5_ClubSystem.Repos.Implementation
{
    public class BookingRepo : GenericRepo<Booking>, IBookingRepository
    {

        private readonly ClubDbContext _context;
        public BookingRepo(ClubDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Booking>> GetBookingsAsync(
            int pageNumber,
            int pageSize,
            string? status,
            int? facilityId)
        {
            IQueryable<Booking> query = _context.Bookings
                .Include(b => b.Member)
                .Include(b => b.Facility);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(b => b.Status == status);

            if (facilityId.HasValue)
                query = query.Where(b => b.FacilityId == facilityId);

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookingReportDto>> GetBookingReportAsync()
        {
            return await _context.Bookings
                .GroupBy(b => b.Facility.Name)
                .Select(g => new BookingReportDto
                {
                    FacilityName = g.Key,
                    TotalBookings = g.Count(),
                    TotalVisitors = g.Sum(x => x.GroupSize)
                })
                .ToListAsync();
        }

        public async Task CancelBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking != null)
                booking.Status = "Cancelled";
        }

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.Member)
                .Include(b => b.Facility)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}

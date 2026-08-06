using Case5_ClubSystem.AppDbContext;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case5_ClubSystem.Repos.Implementation
{
    public class FacilityRepo : GenericRepo<Facility>, IFacilityRepository
    {

        private readonly ClubDbContext _context;

        public FacilityRepo(ClubDbContext context) : base(context)
        {

            _context = context;
        }


        public async Task<IEnumerable<Facility>> GetFacilitiesAsync(string? sortBy)
        {
            IQueryable<Facility> query = _context.Facilities;

            switch (sortBy?.ToLower())
            {
                case "name":
                    query = query.OrderBy(f => f.Name);
                    break;

                case "price":
                    query = query.OrderBy(f => f.HourlyPrice);
                    break;

                case "capacity":
                    query = query.OrderByDescending(f => f.Capacity);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<bool> HasBookingsAsync(int facilityId)
        {
            return await _context.Bookings
                .AnyAsync(b => b.FacilityId == facilityId);
        }




    }
}

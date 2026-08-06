using Case5_ClubSystem.AppDbContext;
using Case5_ClubSystem.Repos.Interface;

namespace Case5_ClubSystem.Repos.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClubDbContext _context;



        public IMemberRepository Members { get; }

        public IMembershipRepository Memberships { get; }

        public IFacilityRepository Facilities { get; }

        public IBookingRepository Bookings { get; }

        public IPaymentRepository Payments { get; }


        public UnitOfWork(
                   ClubDbContext context,
                   IMemberRepository members,
                   IMembershipRepository memberships,
                   IFacilityRepository facilities,
                   IBookingRepository bookings,
                   IPaymentRepository payments)
        {
            _context = context;

            Members = members;
            Memberships = memberships;
            Facilities = facilities;
            Bookings = bookings;
            Payments = payments;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}

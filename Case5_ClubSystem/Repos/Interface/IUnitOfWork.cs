namespace Case5_ClubSystem.Repos.Interface
{
    public interface IUnitOfWork
    {
        IMemberRepository Members { get; }

        IMembershipRepository Memberships { get; }

        IFacilityRepository Facilities { get; }

        IBookingRepository Bookings { get; }

        IPaymentRepository Payments { get; }

        Task<int> CompleteAsync();
    }
}

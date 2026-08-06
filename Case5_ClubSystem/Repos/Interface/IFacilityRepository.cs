using Case5_ClubSystem.Repos.Interface;
using Case5_ClubSystem.Models;

namespace Case5_ClubSystem.Repos.Interface
{
    public interface IFacilityRepository :IGenericRepo<Facility>
    {

        Task<IEnumerable<Facility>> GetFacilitiesAsync(string? sortBy);

        Task<bool> HasBookingsAsync(int facilityId);
    }
}

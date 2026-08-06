using Case5_ClubSystem.Repos.Interface;
using Case5_ClubSystem.Models;

namespace Case5_ClubSystem.Repos.Interface
{
    public interface IMembershipRepository : IGenericRepo<Membership>
    {

        Task<IEnumerable<Membership>> GetActiveMembershipsAsync();

        Task RenewMembershipAsync(int id);
    }
}

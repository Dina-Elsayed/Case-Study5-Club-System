using Case5_ClubSystem.Repos.Interface;
using Case5_ClubSystem.Models;

namespace Case5_ClubSystem.Repos.Interface
{
    public interface IMemberRepository : IGenericRepo<Member>
    {
        Task<IEnumerable<Member>> GetMembersAsync(
                    int pageNumber,
                    int pageSize,
                    string? sortBy);

        Task<IEnumerable<Member>> SearchByNameAsync(string name);
    }
}

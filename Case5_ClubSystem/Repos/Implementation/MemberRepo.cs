using Case5_ClubSystem.Repos.Implementation;
using Case5_ClubSystem.AppDbContext;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case5_ClubSystem.Repos.Implementation
{
    public class MemberRepo : GenericRepo<Member> , IMemberRepository
    {

        private readonly ClubDbContext _context;

        public MemberRepo(ClubDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetMembersAsync(
           int pageNumber,
           int pageSize,
           string? sortBy)
        {
            IQueryable<Member> query = _context.Members;

            switch (sortBy?.ToLower())
            {
                case "name":
                    query = query.OrderBy(m => m.FullName);
                    break;

                case "birthdate":
                    query = query.OrderBy(m => m.BirthDate);
                    break;

                default:
                    query = query.OrderBy(m => m.Id);
                    break;
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

      
        public async Task<IEnumerable<Member>> SearchByNameAsync(string name)
        {
            return await _context.Members
                .Where(m => m.FullName.Contains(name))
                .ToListAsync();
        }





    }
}

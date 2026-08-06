using Case5_ClubSystem.AppDbContext;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case5_ClubSystem.Repos.Implementation
{
    public class MembershipRepo: GenericRepo<Membership>, IMembershipRepository
    {
        private readonly ClubDbContext _context;

        public MembershipRepo(ClubDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Membership>> GetActiveMembershipsAsync()
        {
            return await _context.Memberships
                .Include(m => m.Member)
                .Where(m => m.Status == "Active")
                .ToListAsync();
        }

        public async Task RenewMembershipAsync(int id)
        {
            var membership = await _context.Memberships.FindAsync(id);

            if (membership != null)
            {
                membership.StartDate = DateTime.Today;
                switch (membership.Type)
                {
                    case "Monthly":
                        membership.EndDate = membership.StartDate.AddMonths(1);
                        break;

                    case "Quarterly":
                        membership.EndDate = membership.StartDate.AddMonths(3);
                        break;

                    case "Yearly":
                        membership.EndDate = membership.StartDate.AddYears(1);
                        break;
                }
                membership.Status = "Active";
            }
        }
    }
}

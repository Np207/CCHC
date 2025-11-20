using LHS_API.Data;
using LHS_API.Interfaces;
using LHS_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LHS_API.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>
    {
        public ProfileRepository(DBContext context) : base(context)
        {
 
        }

        public async Task<IEnumerable<Profile>> GetFilterByRole(string id)
        {
            var profiles = await _dbContext.Accounts
            .Where(a => a.RoleId == Guid.Parse(id))
            .Select(a => a.Profile)
            .ToListAsync();

            return profiles;
        }
    }
}

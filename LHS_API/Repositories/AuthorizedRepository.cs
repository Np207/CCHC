using LHS_API.Data;
using LHS_API.Interfaces;
using LHS_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LHS_API.Repositories
{
    public class AuthorizedRepository : BaseRepository<Authorized>
    {
        public AuthorizedRepository(DBContext context) : base(context) { }

        public async Task<IEnumerable<string>> GetPermissionCodesByRole(string roleId)
        {
            // Get all PermissionIds for this role
            var permissionIds = await _dbContext.Authorized
                .Where(a => a.RoleId == Guid.Parse(roleId))
                .Select(a => a.PermissionId)      // Get PermissionId
                .ToListAsync();

            // Get the corresponding permission codes
            var permissionCodes = await _dbContext.Permissions
                .Where(p => permissionIds.Contains(p.Id)) // match PermissionId
                .Select(p => p.Code)                      // select the code
                .ToListAsync();

            return permissionCodes;
        }
    }
}

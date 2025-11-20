using LHS_API.Data;
using LHS_API.Interfaces;
using LHS_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LHS_API.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(DBContext context) : base(context) { }

    }
}

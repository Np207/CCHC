using LHS_API.Interfaces;
using LHS_API.Repositories;
using LHS_Models.Models;

namespace LHS_API.Services
{
    public class ProfileService : BaseService<Profile,ProfileRepository>
    {
        private readonly RoleRepository _roleRepo;

        public ProfileService(ProfileRepository repo, RoleRepository roleRepo) : base(repo) {
            _roleRepo = roleRepo;
        }

        public async Task<IEnumerable<Profile>> CallService_GetProfilesByRoleId(string id)
        {
            var role = await _roleRepo.GetOneAsync(id);

            if (role == null) return Enumerable.Empty<Profile>();
            
            return await _thisRepo.GetFilterByRole(role.Id.ToString());
        }
    }
}

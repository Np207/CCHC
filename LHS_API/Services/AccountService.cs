using LHS_API.Interfaces;
using LHS_API.Repositories;
using LHS_Models.DTOs;
using LHS_Models.Models;

namespace LHS_API.Services
{
    public class AccountService : BaseService<Account, AccountRepository>
    {
        private readonly RoleRepository _roleRepo;
        private readonly AuthorizedRepository _authorizedRepo;
        public AccountService(AccountRepository repo, RoleRepository roleRepo, AuthorizedRepository authorizedRepo) : base(repo) {
            _roleRepo = roleRepo;
            _authorizedRepo = authorizedRepo;
        }

        public async Task<Account> CallService_ValidateLogin(string username, string password)
        {
            return await _thisRepo.ValidateLogin(username, password);
        }

        public async Task<IEnumerable<string>> CallService_GetPermissionCodesByRole(string roleId)
        {
            return await _authorizedRepo.GetPermissionCodesByRole(roleId);
        }


        public async Task<StatusResponse> CallService_Register(LHS_Models.DTOs.RegisterRequest input)
        {
            //ObjectId profileId = ObjectId.GenerateNewId();

            //var profile = new Profile
            //{
            //    Id = profileId.ToString(),
            //    Name = input.Name,
            //    Email = input.Email,
            //    PhoneNumber = input.PhoneNumber
            //};

            //var account = new Account {
            //    Username = input.Username,
            //    Password = input.Password,
            //    RoleId = "00ceba359379a534cfa09df3",
            //    CreatedDate = DateTime.UtcNow,
            //    IsActived = true,
            //    ProfileId = profileId.ToString()
            //};

            //try
            //{
            //    await this.CreateAsync(account);
            //    await _profileRepository.CreateAsync(profile);

            //    return new StatusResponse
            //    {
            //        StatusCode = 201,
            //        StatusMessage = "Ok"
            //    };
            //} 
            //catch (Exception e)
            //{
            //    return new StatusResponse
            //    {
            //        StatusCode = 500,
            //        StatusMessage = e.Message
            //    };
            //}
            return null;
        }
    }
}

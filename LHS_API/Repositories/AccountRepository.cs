using LHS_API.Data;
using LHS_API.Interfaces;
using LHS_Models.DTOs;
using LHS_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LHS_API.Repositories
{
    public class AccountRepository : BaseRepository<Account>
    {
        public AccountRepository(DBContext context) : base(context)
        {
            
        }

        public async Task<Account> ValidateLogin(string username, string password)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Username == username && a.Password == password);
        }

        public async Task<StatusResponse> Register(LHS_Models.DTOs.RegisterRequest input)
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

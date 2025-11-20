using LHS_API.Services;
using LHS_Client;
using LHS_Client.Attributes;
using LHS_Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LHS_API.Controllers
{

    public class ProfileController : BaseController<Profile, ProfileService>
    {
        public ProfileController(ProfileService service, JwtHelper jwtHelper) : base(service, jwtHelper) { }

        [HttpGet("GetFilterByRole")]
        [Authorized(PermissionCode = "view-profile-list")]
        public async Task<IActionResult> GetFilterByRole(string roleId)
        {
            return Ok(await _service.CallService_GetProfilesByRoleId(roleId));
        }
    }
}

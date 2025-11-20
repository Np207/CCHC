using System.Net;
using LHS_API.Repositories;
using LHS_API.Services;
using LHS_Client;
using LHS_Models.DTOs;
using LHS_Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LHS_API.Controllers
{
    [Authorize]
    public class AccountController : BaseController<Account, AccountService>
    {
        public AccountController(AccountService service, JwtHelper jwtHelper) : base(service, jwtHelper)
        { }

        [AllowAnonymous]
        [HttpPost("ValidateLogin")]
        public async Task<IActionResult> ValidateLogin(LHS_Models.DTOs.LoginRequest input)
        {
            var result = await _service.CallService_ValidateLogin(input.Username, input.Password);

            if(result != null)
            {
                var token = _jwtHelper.GenerateToken(result.Id.ToString());
 
                LoginResponse response = new LoginResponse
                {
                    Token = token,
                    LoginAccount = result
                };
                
                return Ok(response);
            }
            else
            {
                return StatusCode(404);
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(LHS_Models.DTOs.RegisterRequest input)
        {
            var result = await _service.CallService_Register(input);

            if (result.StatusCode == 201)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(result.StatusCode);
            }
        }


        [AllowAnonymous]
        [HttpGet("GetPermissionCodesByRole")]
        public async Task<IActionResult> GetPermissionCodesByRole(string roleId)
        {
            return Ok(await _service.CallService_GetPermissionCodesByRole(roleId));
        }
    }
}

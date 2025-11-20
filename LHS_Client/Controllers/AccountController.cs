using System.Text.Json;
using LHS_Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LHS_Client.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory,"api/account") { }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LHS_Models.DTOs.LoginRequest loginData)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_url}/validateLogin", loginData);

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentType?.MediaType == "application/json")
            {
                var responseData = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (responseData != null)
                {
                    HttpContext.Session.SetString("Token", responseData.Token);
                    HttpContext.Session.SetString("SessionAccount", JsonSerializer.Serialize(responseData.LoginAccount));

                    var getPermissionCodes = await _httpClient.GetAsync($"{_url}/getPermissionCodesByRole?roleId={responseData.LoginAccount.RoleId}");

                    if (getPermissionCodes.IsSuccessStatusCode)
                    {
                        // Read the response as a string
                        var jsonString = await getPermissionCodes.Content.ReadAsStringAsync();
                        // Store JSON string in session
                        HttpContext.Session.SetString("PermissionCodes", jsonString);
                        var aa = HttpContext.Session.GetString("PermissionCodes");

                        var jsonString2 = await getPermissionCodes.Content.ReadAsStringAsync();
                    }
                  
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return BadRequest(response.StatusCode);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] LHS_Models.DTOs.RegisterRequest regData)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_url}/register", regData);

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentType?.MediaType == "application/json")
            {
                var responseData = await response.Content.ReadFromJsonAsync<StatusResponse>();

                if (responseData != null)
                {
                    return View("Login");
                }
                else
                {
                    return View("Register");
                }
            }
            else
            {
                return BadRequest(response.StatusCode);
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {           
            HttpContext.Session.SetString("Token", null);
            HttpContext.Session.SetString("SessionAccount", null);
            HttpContext.Session.SetString("IsAdmin", null);
            return RedirectToAction("Index", "Home");
        }
    }
}

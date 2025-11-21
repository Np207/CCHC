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
                        var json = await getPermissionCodes.Content.ReadAsStringAsync();
                        var codes = JsonSerializer.Deserialize<List<string>>(json);

                        HttpContext.Session.SetObject("PermissionCodes", codes);
                        var aa = HttpContext.Session.GetObject<List<string>>("PermissionCodes");
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

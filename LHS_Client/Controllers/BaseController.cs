using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using LHS_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHS_Client.Controllers
{
    public class BaseController : Controller
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _url;

        public BaseController(IHttpClientFactory httpClientFactory, string url)
        {
            _httpClient = httpClientFactory.CreateClient("api");
            _url = url;
        }

        protected async Task<IActionResult> Authenticate()
        {
            var token = HttpContext.Session.GetString("Token");
            var sessionAccount = HttpContext.Session.GetString("SessionAccount");
            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            } else if (sessionAccount == null || string.IsNullOrEmpty(sessionAccount))
            {
                return RedirectToAction("Login", "Account");
            }

            return Ok();
        }

        protected Account GetSessionAccount()
        {
            var sessionData = HttpContext.Session.GetString("SessionAccount");

            if (!string.IsNullOrEmpty(sessionData))
            {
                return JsonSerializer.Deserialize<Account>(HttpContext.Session.GetString("SessionAccount"));
            } else
            {
                return new Account();
            }
        }

        protected bool ValidateAdmin()
        {
            var value = HttpContext.Session.GetString("IsAdmin"); // returns string or null
            return value != null && bool.Parse(value);           // convert to bool
        }
    }
}
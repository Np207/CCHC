using LHS_Client.Attributes;
using LHS_Models.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace LHS_Client.Controllers
{
    [Route("QuestionBank")]
    public class QuestionBankController : BaseController
    {
        public QuestionBankController(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "api/questionBank") { }

        [HttpGet("Get")]
        public async Task<IActionResult> Index()
        {
            Authenticate();

            var response = await _httpClient.GetAsync($"{_url}/getAll");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<QuestionBank>>();
                return View(data);
            }
            else
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized("Unauthorized!");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound("Not found!");
                }
                else
                {
                    return BadRequest("Request Error!");
                }
            }
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            Authenticate();

            QuestionBank bank = new QuestionBank();
            bank.Questions = new List<Question>() { new Question()};
            return View(bank);
        }

        //[HttpGet("Update")]
        //public async Task<IActionResult> Update(string id)
        //{
        //    Authenticate();

        //    string? decryptedId = JwtHelper.ValidateToken(id);
        //    if (string.IsNullOrEmpty(decryptedId))
        //    {
        //        return BadRequest("Invalid token!");
        //    }

        //    var response = await _httpClient.GetFromJsonAsync<Profile>($"{_url}/getOne/{decryptedId}");

        //    if (response != null)
        //    {
        //        return View(response);
        //    }
        //    else
        //    {
        //        return BadRequest("Data does not existed!");
        //    }
        //}

        //[HttpGet("Delete")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    Authenticate();

        //    string? decryptedId = JwtHelper.ValidateToken(id);
        //    if (string.IsNullOrEmpty(decryptedId))
        //    {
        //        return BadRequest("Invalid token");
        //    }

        //    var response = await _httpClient.GetFromJsonAsync<Profile>($"{_url}/getOne/{decryptedId}");

        //    if (response != null)
        //    {
        //        return View(response);
        //    }
        //    else
        //    {
        //        return BadRequest("Data does not existed!");
        //    }
        //}


        //[HttpPost("Create")]
        //public async Task<IActionResult> CreateOne([FromForm] QuestionBank bank)
        //{
        //    var response = await _httpClient.PostAsJsonAsync($"{_url}/addOne", bank);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        string error = await response.Content.ReadAsStringAsync();
        //        ModelState.AddModelError(await response.Content.ReadAsStringAsync(), "Failed to create.");
        //        return RedirectToAction("Index");
        //    }
        //}

        //[HttpPost("Update")]
        //public async Task<IActionResult> UpdateOne([FromForm] Profile profile)
        //{
        //    string? decryptedId = JwtHelper.ValidateToken(profile.Id.ToString());
        //    if (string.IsNullOrEmpty(decryptedId))
        //    {
        //        return BadRequest("Invalid token");
        //    }

        //    //*IMPORTANT: Remember to set decrypted id to model*
        //    profile.Id = Guid.Parse(decryptedId);

        //    await _httpClient.PutAsJsonAsync($"{_url}/editOne?id={decryptedId}", profile);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet("Detail")]
        //public async Task<IActionResult> Detail(string id)
        //{
        //    string? decryptedId = JwtHelper.ValidateToken(id);
        //    if (string.IsNullOrEmpty(decryptedId))
        //    {
        //        return BadRequest("Invalid token");
        //    }

        //    var response = await _httpClient.GetFromJsonAsync<Profile>($"{_url}/getOne/{decryptedId}");

        //    if (response != null)
        //    {
        //        return View(response);
        //    }
        //    else
        //    {
        //        return BadRequest("Data does not existed!");
        //    }
        //}

        //[HttpPost("Delete")]
        //public async Task<IActionResult> DeleteOne(string id)
        //{
        //    string? decryptedId = JwtHelper.ValidateToken(id);
        //    if (string.IsNullOrEmpty(decryptedId))
        //    {
        //        return BadRequest("Invalid token");
        //    }

        //    var response = await _httpClient.DeleteAsync($"{_url}/removeOne/{decryptedId}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        string error = await response.Content.ReadAsStringAsync();
        //        ModelState.AddModelError(await response.Content.ReadAsStringAsync(), "Failed to delete teacher.");
        //        return RedirectToAction("Index");
        //    }
        //}
    }
}

using LHS_API.Services;
using LHS_Client;
using LHS_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHS_API.Controllers
{
    public class QuestionBankController : BaseController<QuestionBank, QuestionBankService>
    {
        public QuestionBankController(QuestionBankService service, JwtHelper jwtHelper) : base(service, jwtHelper) { }
    }
}

using LHS_API.Interfaces;
using LHS_API.Repositories;
using LHS_Models.Models;

namespace LHS_API.Services
{
    public class QuestionBankService : BaseService<QuestionBank,QuestionBankRepository>
    {
        public QuestionBankService(QuestionBankRepository repo) : base(repo) {
   
        }
    }
}

using LHS_API.Interfaces;
using LHS_API.Repositories;
using LHS_Models.Models;

namespace LHS_API.Services
{
    public class QuestionService : BaseService<Question,QuestionRepository>
    {
        public QuestionService(QuestionRepository repo) : base(repo) {
   
        }
    }
}

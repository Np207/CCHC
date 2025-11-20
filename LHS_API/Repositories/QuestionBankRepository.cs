using LHS_API.Data;
using LHS_API.Interfaces;
using LHS_Models.DTOs;
using LHS_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LHS_API.Repositories
{
    public class QuestionBankRepository : BaseRepository<QuestionBank>
    {
        public QuestionBankRepository(DBContext context) : base(context)
        {
            
        }
    }
}

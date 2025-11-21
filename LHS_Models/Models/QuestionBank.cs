using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHS_Models.Models
{
    public class QuestionBank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}

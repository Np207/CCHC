using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHS_Models.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string QuestionCode { get; set; }

        public string Content { get; set; }

        public string[] Answers { get; set; }

        /**/

        [ForeignKey("QuestionBank")]
        public Guid QuestionBankId { get; set; }
        public QuestionBank Bank { get; set; }
    }
}

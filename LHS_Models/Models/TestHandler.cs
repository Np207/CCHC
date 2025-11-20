using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHS_Models.Models
{
    public class TestHandler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string TestName { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FinishDate { get; set; }

        public float TestTimeCountdown { get; set; } /*In minutes*/

        [ForeignKey("QuestionBank")]
        public Guid BankId { get; set; }
        public QuestionBank Bank { get; set; }
        public TestRecord[] TestRecord { get; set; }
    }
}

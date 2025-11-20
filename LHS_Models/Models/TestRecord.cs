using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHS_Models.Models
{
    public class TestRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
       
        [DataType(DataType.DateTime)]
        public DateTime FinishTime { get; set; }

        public int TotalScore { get; set; }

        [ForeignKey("Account")]
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        [ForeignKey("TestHandler")]
        public Guid TestHandlerId { get; set; }
        public TestHandler TestHandler { get; set; }
    }
}

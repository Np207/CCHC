using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHS_Models.Models
{
    public class Authorized
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [ForeignKey("RoleId")]
        public Guid? RoleId { get; set; }

        [ForeignKey("Permission")]
        public Guid? PermissionId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LHS_Models.Models
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        public DateOnly? DateOfBirth { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [ForeignKey("Department")]
        public Guid? DepId { get; set; }
        public Department Department { get; set; }
    }
}

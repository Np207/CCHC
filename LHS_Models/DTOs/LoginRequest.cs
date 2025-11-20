using System.ComponentModel.DataAnnotations;

namespace LHS_Models.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set ; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

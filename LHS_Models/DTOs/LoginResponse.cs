using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LHS_Models.Models;
namespace LHS_Models.DTOs
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public Account LoginAccount { get; set; }
    }
}

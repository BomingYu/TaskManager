using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Account
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        public string Password {get;set;}
    }
}
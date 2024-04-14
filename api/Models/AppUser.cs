using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser:IdentityUser
    {
        public string Role {get;set;} = string.Empty;
        public List<Massion> Massions {get;set;} = new List<Massion>();
    }
}
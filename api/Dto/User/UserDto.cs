using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Massion;
using api.Models;

namespace api.Dto.User
{
    public class UserDto
    {
         public int Id {get;set;}

        public string Name {get;set;} = string.Empty;

        public string Email {get;set;} = string.Empty;

        //public string Password {get;set;} = string.Empty;

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public List<MassionDto> Massions {get;set;}
    }
}
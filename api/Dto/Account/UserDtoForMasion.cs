using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Massion;

namespace api.Dto.Account
{
    public class UserDtoForMasion
    {
        public string Id {get;set;}
        public string UserName {get;set;}

        public string Email {get;set;}

        public List<MassionDto> Massions {get;set;} = new List<MassionDto>();
    }
}
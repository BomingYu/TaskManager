using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Account;
using api.Models;

namespace api.Mapper
{
    public static class AppUserMapper
    {
        public static UserDtoForMasion ToUserDtoForMassion(this AppUser appUserModel){
            return new UserDtoForMasion {
                Id = appUserModel.Id,
                UserName = appUserModel.UserName,
                Email = appUserModel.Email,
                Massions = appUserModel.Massions.Select(m => m.ToMassionDto()).ToList()
            };
        }
    }
}
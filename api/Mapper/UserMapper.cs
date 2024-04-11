using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.User;
using api.Models;

namespace api.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto (this User userModel){
            return new UserDto{
                Id = userModel.Id,
                Name = userModel.Name,
                Email = userModel.Email,
                //Password = userModel.Password,
                CreatedAt = userModel.CreatedAt,
                Massions = userModel.Massions.Select(m => m.ToMassionDto()).ToList()
            };
        } 
    }
}
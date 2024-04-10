using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser(){
            var usersModelRes = await _userRepo.GetAll();
            var usersDto = usersModelRes.Select(u => u.ToUserDto());
            return Ok(usersDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id){
            var userModelRes = await _userRepo.GetById(id);
            if(userModelRes == null){
                return NotFound();
            }
            return Ok(userModelRes.ToUserDto());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Account;
using api.Dto.User;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        //private readonly
        public AccountController(UserManager<AppUser> userManager , ITokenService tokenService , SignInManager<AppUser> signManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userCreateDto){
            try{
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                var appUser = new AppUser{
                    UserName = userCreateDto.UserName,
                    Email = userCreateDto.Email,
                    Role = "customer"
                };
                var createdUser = await _userManager.CreateAsync(appUser , userCreateDto.Password);
                if(createdUser.Succeeded){
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if(roleResult.Succeeded){
                        return Ok(new NewUserDto{
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    }
                    else{
                        return StatusCode(500,roleResult.Errors);
                    }
                }
                else{
                    return StatusCode(500,createdUser.Errors);
                }
            }
            catch(Exception ex){
                return StatusCode(500,ex);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if(user == null){
                return NotFound("Invalid User Email");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user , loginDto.Password , false);

            if(!result.Succeeded){
                return Unauthorized("Invalid User Email or Invalid Password");
            }

            return Ok(
                new NewUserDto{
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(){
            var users = await _userManager.Users.Include(u=>u.Massions).ToListAsync();
            var userDto = users.Select(u=>u.ToUserDtoForMassion());
            return Ok(userDto);
        }
    }
}
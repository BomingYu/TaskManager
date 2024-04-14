using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Massion;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/massions")]
    [ApiController]
    public class MassionController:ControllerBase
    {
        private readonly IMassionRepository _massionRepo;
        private readonly IUserRepository _userRepo;

        private readonly UserManager<AppUser> _userManager;

        public MassionController(IMassionRepository massionRepo , IUserRepository userRepo , UserManager<AppUser> userManager)
        {
            _massionRepo = massionRepo;
            _userRepo = userRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllMassion(){
            var massionList = await _massionRepo.GetAll();
            var massionDtoList = massionList.Select(m => m.ToMassionDto());
            return Ok(massionDtoList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMassionById([FromRoute] int id){
            var massionRes = await _massionRepo.GetById(id);
            if(massionRes == null){
                return NotFound();
            }
            return Ok(massionRes.ToMassionDto());
        }

        [HttpGet]
        [Route("user/{uid}")]
        public async Task<IActionResult> GetMassionByUser ([FromRoute] string uid){
            var massionsRes = await _massionRepo.GetMassionsByUser(uid);
            var massionDtoList = massionsRes.Select(m => m.ToMassionDto()).ToList();
            return Ok(massionDtoList);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> CreateNewMassion([FromRoute] string id , [FromBody] MassionCreateDto massionDto){
            //var userExist1 = await _userRepo.Existed(id);
            var userExist = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(userExist == null){
                return NotFound();
            }
            var massionModel = massionDto.ToMassionFromCreateDto(id);
            var massionModelRes = await _massionRepo.Create(massionModel);
            return Ok(massionModelRes.ToMassionDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMassion([FromRoute] int id , [FromBody] MassionUpdateDto massionDto){
            var massion = massionDto.ToMassionFromUpdateDto();
            var massionModelRes = await _massionRepo.Update(id , massion);
            if(massionModelRes == null){
                return NotFound();
            }
            return Ok(massionModelRes.ToMassionDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMassion([FromRoute] int id){
            var massion = await _massionRepo.Delete(id);
            if(massion == null){
                return NotFound();
            }
            return Ok(massion.ToMassionDto());
        }

        [HttpPost]
        [Route("{mId}/{tId}")]
        public async Task<IActionResult> AddTag([FromRoute] int mId , [FromRoute] int tId){
            var massionRes = await _massionRepo.AddTag(mId , tId);
            if(massionRes == null){
                return NotFound();
            }
            return Ok(massionRes.ToMassionDto());
        }

        [HttpDelete]
        [Route("{mId}/{tId}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int mId , [FromRoute] int tId){
            var massionRes = await _massionRepo.DeleteTag(mId , tId);
            if(massionRes == null){
                return NotFound();
            }
            return Ok(massionRes.ToMassionDto());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Submassion;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace api.Controllers
{
    [Route("api/submassions")]
    [ApiController]
    public class SubMassionController:ControllerBase
    {
        private readonly ISubMassionRepository _subMassionRepo;
        private readonly IMassionRepository _maasionRepo;
        public SubMassionController(ISubMassionRepository subMassionRepo,IMassionRepository massionRepo)
        {
            _subMassionRepo = subMassionRepo;
            _maasionRepo = massionRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubMassion(){
            var subMassionList = await _subMassionRepo.GetAll();
            var subMassionListDto = subMassionList.Select(s => s.ToSubMassionDto());
            return Ok(subMassionListDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSubMassionById([FromRoute] int id){
            var subMassionModelRes = await _subMassionRepo.GetById(id);
            if(subMassionModelRes == null){
                return NotFound();
            }
            return Ok(subMassionModelRes.ToSubMassionDto());
        }

        [HttpPost]
        [Route("{massionId}")]
        public async Task<IActionResult> CreateSubMassion([FromRoute] int massionId , [FromBody] SubMassionCreateDto subMassionDto){
            var isMassion = await _maasionRepo.IsMassionExist(massionId);
            if(isMassion){
                var subMassionModel = subMassionDto.ToSubMassionFromCreateDto(massionId);
                var subMassionModelRes = await _subMassionRepo.Create(subMassionModel);
                return Ok(subMassionModelRes.ToSubMassionDto());
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSubMassion([FromRoute] int id , [FromBody] SubMassionUpdateDto subMassionUpdateDto){
            var subMassionModel = subMassionUpdateDto.ToSubMassionFromUpdateDto();
            var subMassionModelRes = await _subMassionRepo.Update(id,subMassionModel);
            if(subMassionModelRes == null){
                return NotFound();
            }
            return Ok(subMassionModelRes.ToSubMassionDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSubMassion([FromRoute] int id){
            var subMassionRes = await _subMassionRepo.Delete(id);
            if(subMassionRes == null){
                return NotFound();
            }
            return Ok(subMassionRes.ToSubMassionDto());
        }
    }
}
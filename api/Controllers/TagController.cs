using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Tag;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagController:ControllerBase
    {
        private readonly ITagRepository _tagRepo;
        public TagController(ITagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTags(){
            var tagsListRes = await _tagRepo.GetAll();
            var tagsListDto =  tagsListRes.Select(t => t.ToTagDto());
            return Ok(tagsListDto);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTagById([FromRoute] int id){
            var tagRes = await _tagRepo.GetById(id);
            if(tagRes == null){
                return NotFound();
            }
            return Ok(tagRes.ToTagDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] TagCreateUpdateDto tagDto){
            var tagModel = tagDto.ToTagFromCreatUpdateDto();
            var tagRes = await _tagRepo.Create(tagModel);
            return Ok(tagDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task <IActionResult> UpdateTag([FromRoute] int id , [FromBody] TagCreateUpdateDto tagDto){
            var tagModel = tagDto.ToTagFromCreatUpdateDto();
            var tagRes = await _tagRepo.Update(id,tagModel);
            if(tagRes == null){
                return NotFound();
            }
            return Ok(tagRes.ToTagDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int id){
            var tagRes = await _tagRepo.Delete(id);
            if(tagRes == null){
                return NotFound();
            }
            return Ok(tagRes.ToTagDto());
        }
    }
}
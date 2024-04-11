using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Tag;
using api.Models;

namespace api.Mapper
{
    public static class TagMapper
    {
        public static TagDto ToTagDto (this Tag tagModel){
            return new TagDto{
                Id = tagModel.Id,
                Name = tagModel.Name,
                Color = tagModel.Color,
                Massions = tagModel.Massions.Select(m => m.ToMassionDtoForTag()).ToList()
            };
        }
        public static Tag ToTagFromCreatUpdateDto (this TagCreateUpdateDto tagDto){
            return new Tag{
                Name = tagDto.Name,
                Color = tagDto.Color
            };
        }

        public static TagDtoForMassion ToTagDtoForMassion (this Tag tagModel){
            return new TagDtoForMassion{
                Id = tagModel.Id,
                Name = tagModel.Name,
                Color = tagModel.Color
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Submassion;
using api.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace api.Mapper
{
    public static class SubMassionMapper
    {
        public static SubMassionDto ToSubMassionDto(this SubMassion subMasionModel){
            return new SubMassionDto{
                Id = subMasionModel.Id,
                Title = subMasionModel.Title,
                Description = subMasionModel.Description,
                Priority = subMasionModel.Priority,
                Status = subMasionModel.Status,
                MassionId = subMasionModel.MassionId
            };
        }
        public static SubMassion ToSubMassionFromCreateDto(this SubMassionCreateDto subMassionDto, int massionId){
            return new SubMassion{
                Title = subMassionDto.Title,
                Description = subMassionDto.Description,
                Priority = subMassionDto.Priority,
                Status = "todo",
                MassionId = massionId
            };
        }

        public static SubMassion ToSubMassionFromUpdateDto(this SubMassionUpdateDto subMassionDto){
            return new SubMassion{
                Title = subMassionDto.Title,
                Description = subMassionDto.Description,
                Priority = subMassionDto.Priority,
                Status = subMassionDto.Status
            };
        }
    }
}
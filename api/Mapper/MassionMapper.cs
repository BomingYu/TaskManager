using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Massion;
using api.Models;

namespace api.Mapper
{
    public static class MassionMapper
    {
        public static MassionDto ToMassionDto(this Massion massionModel){
            return new MassionDto{
                Id = massionModel.Id,
                Title = massionModel.Title,
                Description = massionModel.Description,
                CreatedAt = massionModel.CreatedAt,
                DueAt = massionModel.DueAt,
                Priority = massionModel.Priority,
                Status = massionModel.Status,
                UserId = massionModel.UserId,
                SubMissions = massionModel.SubMissions.Select(s => s.ToSubMassionDto()).ToList(),
                Tags = massionModel.Tags.Select(t => t.ToTagDtoForMassion()).ToList()
            };
        }

        public static Massion ToMassionFromCreateDto(this MassionCreateDto massionDto , string userId){
            return new Massion{
                Title = massionDto.Title,
                Description = massionDto.Description,
                DueAt = massionDto.DueAt,
                Priority = massionDto.Priority,
                Status = "todo",
                UserId = userId
            };
        }

        public static Massion ToMassionFromUpdateDto(this MassionUpdateDto massionDto){
            return new Massion{
                Title = massionDto.Title,
                Description = massionDto.Description,
                DueAt = massionDto.DueAt,
                Priority = massionDto.Priority,
                Status = massionDto.Status
            };
        }

        public static MassionDtoForTag ToMassionDtoForTag(this Massion massionModel){
            return new MassionDtoForTag{
                Id = massionModel.Id,
                Title = massionModel.Title,
                Description = massionModel.Description,
                CreatedAt = massionModel.CreatedAt,
                DueAt = massionModel.DueAt,
                Priority = massionModel.Priority,
                Status = massionModel.Status,
                UserId = massionModel.UserId,
                SubMissions = massionModel.SubMissions.Select(s=>s.ToSubMassionDto()).ToList()
            };
        }
    }
}
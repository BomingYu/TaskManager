using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Submassion;
using api.Models;

namespace api.Dto.Massion
{
    public class MassionDto
    {
        public int Id {get;set;}

        public string Title {get;set;} = string.Empty;

        public string Description {get;set;} = string.Empty;

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime? DueAt {get;set;}

        public int? Priority {get;set;}

        public string Status {get;set;} = string.Empty;

        public int? UserId {get;set;}

        public List<SubMassionDto> SubMissions {get;set;} = new List<SubMassionDto>();

        //public List<Tag> Tags {get;set;} = new List<Tag>();
    }
}
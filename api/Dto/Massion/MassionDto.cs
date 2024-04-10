using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //public User? User {get;set;}

        //public List<SubMassion> SubMissions {get;set;} = new List<SubMassion>();

        //public List<Tag> Tags {get;set;} = new List<Tag>();
    }
}
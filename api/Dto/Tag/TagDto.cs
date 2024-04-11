using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Massion;

namespace api.Dto.Tag
{
    public class TagDto
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public string Color {get;set;} = string.Empty;

        public List<MassionDtoForTag> Massions {get;set;} = new List<MassionDtoForTag>();
    }
}
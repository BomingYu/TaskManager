using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Massion
{
    public class MassionUpdateDto
    {
        public string Title {get;set;} = string.Empty;

        public string Description {get;set;} = string.Empty;

        public DateTime? DueAt {get;set;}

        public int? Priority {get;set;}

        public string Status {get;set;} = string.Empty;
    }
}
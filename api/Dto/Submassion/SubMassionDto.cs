using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Submassion
{
    public class SubMassionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int? Priority { get; set; }

        public string Status { get; set; } = string.Empty;

        public int? MassionId { get; set; }

        //public Massion? Massion {get;set;}
    }
}
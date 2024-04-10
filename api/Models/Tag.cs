using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Tag
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;

        public string Color {get;set;} = string.Empty;

        public List<Massion> Massions {get;set;} = new List<Massion>();
    }
}
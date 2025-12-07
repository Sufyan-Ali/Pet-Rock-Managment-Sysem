using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRockManagment.Models
{
    public class PetRock
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? mood { get; set; }
        public bool clean { get; set; }

    }
}
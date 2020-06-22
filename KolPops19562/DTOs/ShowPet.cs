using KolPops19562.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolPops19562.DTOs
{
    public class ShowPet
    {

        public Pet pet { get; set; }

        public List<Volunteer> volunteers { get; set; }

    }
}

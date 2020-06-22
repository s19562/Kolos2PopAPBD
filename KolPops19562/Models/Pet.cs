using System;
using System.Collections.Generic;

namespace KolPops19562.Models
{
    public partial class Pet
    {
        public Pet()
        {
            VolunteerPet = new HashSet<VolunteerPet>();
        }

        public int IdPet { get; set; }
        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime ApprcimateDateOfBirth { get; set; }
        public DateTime? DateAdopted { get; set; }
        public int BreedTypeIdBreedType { get; set; }

        public virtual BreedType BreedTypeIdBreedTypeNavigation { get; set; }
        public virtual ICollection<VolunteerPet> VolunteerPet { get; set; }
    }
}

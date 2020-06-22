using System;
using System.Collections.Generic;

namespace KolPops19562.Models
{
    public partial class VolunteerPet
    {
        public DateTime DataAccepted { get; set; }
        public int PetIdPet { get; set; }
        public int VolunteerIdVolunteer { get; set; }

        public virtual Pet PetIdPetNavigation { get; set; }
        public virtual Volunteer VolunteerIdVolunteerNavigation { get; set; }
    }
}

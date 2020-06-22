using System;
using System.Collections.Generic;

namespace KolPops19562.Models
{
    public partial class Volunteer
    {
        public Volunteer()
        {
            InverseIdSpervisorNavigation = new HashSet<Volunteer>();
            VolunteerPet = new HashSet<VolunteerPet>();
        }

        public int IdVolunteer { get; set; }
        public int? IdSpervisor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime StartingDate { get; set; }

        public virtual Volunteer IdSpervisorNavigation { get; set; }
        public virtual ICollection<Volunteer> InverseIdSpervisorNavigation { get; set; }
        public virtual ICollection<VolunteerPet> VolunteerPet { get; set; }
    }
}

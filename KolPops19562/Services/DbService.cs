using KolPops19562.DTOs;
using KolPops19562.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolPops19562.Services
{
    public class DbService : IDbService
    {
        public string AddPet(Pet pet)
        {

            var db = new s19562Context();

            var rasa = pet.IdBreedType;

            var exist = db.BreedType.Any(i => i.IdBreedType == rasa);
            

            if (!exist)
            {
                var maxId = db.BreedType.Max(a => a.IdBreedType);
                var BreedType = new BreedType
                {

                    IdBreedType = maxId + 1

                };

                db.BreedType.Add(BreedType);
            }

            db.Pet.Add(pet);
            db.SaveChanges();
            return "zwierze dodane --> sprawdz";


        }

        public List<ShowPet> GetPets(DateTime DateRegistered)
        {
            try
            {
                var db = new s19562Context();

                var listPets = db.Pet.ToList();

                List<ShowPet> listShowPets = new List<ShowPet>();


                foreach (Pet p in listPets)
                {
                    var id = db.VolunteerPet.Where(id => id.PetIdPet == p.IdPet).Select(a => a.VolunteerIdVolunteer).FirstOrDefault();

                    var volunteerss = db.Volunteer.Where(v => v.IdVolunteer == id).ToList();

                    var show = new ShowPet
                    {
                        pet = p,
                        volunteers = volunteerss

                    };

                    listShowPets.Add(show);
                }

                var showWithDatePets = listShowPets.Where(d => d.pet.DateRegistered.Year == DateRegistered.Year).OrderBy(d => d.pet.DateRegistered).ToList();
                return showWithDatePets;
            }
            catch
            {
                throw new Exception("zla data");
            }

        }


    

        public List<ShowPet> GetPets()
        {
            var db = new s19562Context();

            var listPets = db.Pet.ToList();

            List<ShowPet> listShowPets = new List<ShowPet>();

            

            foreach(Pet p in listPets)
            {
                var id = db.VolunteerPet.Where(id => id.PetIdPet == p.IdPet).Select(a => a.VolunteerIdVolunteer).FirstOrDefault();

                var volunteerss = db.Volunteer.Where(v => v.IdVolunteer == id).ToList();

                var show = new ShowPet
                {
                    pet = p,
                    volunteers = volunteerss

                };

                listShowPets.Add(show);
            }
            var goodListShowPets = listShowPets.OrderBy(d => d.pet.DateRegistered).ToList();
            return goodListShowPets;

        }
    }
}

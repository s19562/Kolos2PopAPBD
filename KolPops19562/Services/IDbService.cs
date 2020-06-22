using KolPops19562.DTOs;
using KolPops19562.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolPops19562.Services
{
    public interface IDbService
    {

       List< ShowPet> GetPets(DateTime DateRegistered);
       List< ShowPet> GetPets();

        string AddPet(Pet pet);

    }
}

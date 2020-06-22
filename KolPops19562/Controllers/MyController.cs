using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolPops19562.Models;
using KolPops19562.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolPops19562.Controllers
{
    [Route("api/")]
    public class MyController : ControllerBase
    {

        readonly IDbService _service;

        public MyController(IDbService service)
        {
            _service = service;
        }

        //Scaffold-DbContext 'Data Source=db-mssql;Initial Catalog=s19562;Integrated Security=True' Microsoft.EntityFrameworkCore.SqlServer -T Volunteer_Pet, Volunteer, Pet, BreedType -OutputDir Models

        [Route("pets")] 
        [HttpGet]
        public IActionResult GetPets()
        {

            var result = _service.GetPets();
            return Ok(result);
        }

        [Route("pets")]
        [HttpGet("{DateRegistered}")]
        public IActionResult GetPets(DateTime DateRegistered)
        {
            try
            {

                var result = _service.GetPets(DateRegistered);
                return Ok(result);
            }
            catch(Exception e) {
                
                return BadRequest(e.Message);
            }

        }


        [Route("pets")]
        [HttpPost]
        public IActionResult AddPet(Pet pet)
        {

            var result = _service.AddPet(pet);
            return Ok(result);
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetRockManagment.Models;

namespace PetRockManagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetRockController : ControllerBase
    {
        static private List<PetRock> petRocks = new List<PetRock>
        {
            new PetRock
            {
                id = 1,
                name = "ben",
                mood = "happy",
                clean = true
            },
            new PetRock
            {
                id = 2,
                name = "joe",
                mood = "sad",
                clean = false
            },
            new PetRock
            {
                id = 3,
                name = "doey",
                mood = "angry",
                clean = true
            },
        };

        [HttpGet("/")]
        public ActionResult<List<PetRock>> GetAllPetRock()
        {
            return Ok(petRocks);
        }
        [HttpGet("/{id}")]
        public ActionResult<PetRock> GetPetRockById(int id)
        {
            var petRock = petRocks.FirstOrDefault(x => x.id == id);
            if (petRock == null)
                return NotFound();
            return Ok(petRock);
        }
        [HttpPost("/")]
        public ActionResult<PetRock> AddPetRock(PetRock newPetRock)
        {
            if(newPetRock == null)
                return BadRequest();
            newPetRock.id = petRocks.Max(x => x.id) + 1;
            petRocks.Add(newPetRock);
            return CreatedAtAction(nameof(GetPetRockById), new {id = newPetRock.id}, newPetRock);
        }
        [HttpDelete("/{id}")]
        public IActionResult DeletePetRock(int id)
        {
            var petRock = petRocks.FirstOrDefault(x => x.id == id);
            if (petRock == null)
                return NotFound();
            petRocks.Remove(petRock);
            return NoContent();
        }
        [HttpPut("/{id}")]
        public IActionResult UpdatePetRock(int id, PetRock updatedPetRock)
        {
            var petRock = petRocks.FirstOrDefault(x => x.id == id);
            if (petRock == null)
                return NotFound();
            petRock.name = updatedPetRock.name;
            petRock.mood = updatedPetRock.mood;
            petRock.clean = updatedPetRock.clean;
            return NoContent();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRockManagment.Data;
using PetRockManagment.Models;

namespace PetRockManagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetRockController(PetRockDbContext context) : ControllerBase
    {
        private readonly PetRockDbContext _context = context;

        [HttpGet("/")]
        public async Task<ActionResult<List<PetRock>>> GetAllPetRock()
        {
            return Ok(await _context.PetRocks.ToListAsync());
        }
        [HttpGet("/{id}")]
        public async Task<ActionResult<PetRock>> GetPetRockById(int id)
        {
            var petRock = await _context.PetRocks.FindAsync(id);
            if (petRock == null)
                return NotFound();
            return Ok(petRock);
        }
        [HttpPost("/")]
        public async Task<ActionResult<PetRock>> AddPetRock(PetRock newPetRock)
        {
            if(newPetRock == null)
                return BadRequest();
            _context.PetRocks.Add(newPetRock);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPetRockById), new {id = newPetRock.id}, newPetRock);
        }
        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeletePetRock(int id)
        {
            var petRock = await _context.PetRocks.FindAsync(id);
            if (petRock == null)
                return NotFound();
            _context.PetRocks.Remove(petRock);
            
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("/{id}")]
        public async Task<IActionResult> UpdatePetRock(int id, PetRock updatedPetRock)
        {
           var petRock = await _context.PetRocks.FindAsync(id);
            if (petRock == null)
                return NotFound();
            petRock.name = updatedPetRock.name;
            petRock.mood = updatedPetRock.mood;
            petRock.bath = updatedPetRock.bath;
            
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
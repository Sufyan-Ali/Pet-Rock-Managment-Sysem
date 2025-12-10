using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetRockManagment.Models;

namespace PetRockManagment.Data
{
    public class PetRockDbContext(DbContextOptions<PetRockDbContext> options) : DbContext(options)
    {
        public DbSet<PetRock> PetRocks => Set<PetRock>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PetRock>().HasData(
                new PetRock
            {
                id = 1,
                name = "ben",
                mood = "happy",
                bath = true
            },
            new PetRock
            {
                id = 2,
                name = "joe",
                mood = "sad",
                bath = false
            },
            new PetRock
            {
                id = 3,
                name = "doey",
                mood = "angry",
                bath = true
            }
            );
        }
    }
}
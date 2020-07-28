using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremisesTest.Models;

namespace PremisesTest.Data
{
    public class PremisesContext : DbContext
    {
        public PremisesContext (DbContextOptions<PremisesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

    }
}

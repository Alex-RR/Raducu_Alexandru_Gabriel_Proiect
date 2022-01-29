using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raducu_Alexandru_Gabriel_Proiect.Models;

namespace Raducu_Alexandru_Gabriel_Proiect.Data
{
    public class Raducu_Alexandru_Gabriel_ProiectContext : DbContext
    {
        public Raducu_Alexandru_Gabriel_ProiectContext (DbContextOptions<Raducu_Alexandru_Gabriel_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Raducu_Alexandru_Gabriel_Proiect.Models.Event> Event { get; set; }

        public DbSet<Raducu_Alexandru_Gabriel_Proiect.Models.Guest> Guest { get; set; }

        public DbSet<Raducu_Alexandru_Gabriel_Proiect.Models.Location> Location { get; set; }
    }
}

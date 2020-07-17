using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Models;

namespace SacrementPlanner.Data
{
    public class SacramentPlannerContext : DbContext
    {
        public SacramentPlannerContext (DbContextOptions<SacramentPlannerContext> options) : base(options)
        {
        }

        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<SpeakerAssignment> SpeakerAssignment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
            modelBuilder.Entity<SpeakerAssignment>().ToTable("SpeakerAssignment");
        }
    }
}

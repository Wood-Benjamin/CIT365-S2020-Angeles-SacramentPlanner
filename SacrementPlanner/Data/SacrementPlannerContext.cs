using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Models;

namespace SacrementPlanner.Data
{
    public class SacrementPlannerContext : DbContext
    {
        public SacrementPlannerContext (DbContextOptions<SacrementPlannerContext> options) : base(options)
        {
        }

        public DbSet<Speaker> Speaker { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<SpeakerAssignment> SpeakerAssignment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>().ToTable("Speaker");
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
            modelBuilder.Entity<SpeakerAssignment>().ToTable("SpeakerAssignment");

            modelBuilder.Entity<SpeakerAssignment>()
                .HasKey(s => new { s.MeetingID, s.SpeakerID });
        }
    }
}

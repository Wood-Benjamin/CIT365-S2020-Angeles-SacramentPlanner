using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Models;

namespace SacrementPlanner.Data
{
    public class SacrementPlannerContext : DbContext
    {
        public SacrementPlannerContext (DbContextOptions<SacrementPlannerContext> options) : base(options)
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

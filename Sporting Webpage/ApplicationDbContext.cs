using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Data;

namespace SportEU.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CoachData> Coaches { get; set; }
        public DbSet<AthleteData> Athletes { get; set; }
        public DbSet<GroupData> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoachData>().ToTable("Coaches");
            modelBuilder.Entity<AthleteData>().ToTable("Athletes");
            modelBuilder.Entity<GroupData>().ToTable("Groups");

            /* modelBuilder.Entity<CourseAssignment>()
            .HasKey(c => new { c.CourseID, c.InstructorID }); Võib mitu mitmele seose jaoks vaja minna.*/
        }
    }
}

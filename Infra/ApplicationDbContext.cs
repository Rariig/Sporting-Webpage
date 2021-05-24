using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportEU.Data;
using SportEU.Data.Common;
using AthleteData = SportEU.Data.AthleteData;

namespace SportEU.Infra
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext() : this(
            new DbContextOptionsBuilder<ApplicationDbContext>().Options)
        { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<CoachData> Coaches { get; set; }
        public DbSet<AthleteData> Athletes { get; set; }
        public DbSet<GroupData> Groups { get; set; }
        public DbSet<GroupAssignmentData> GroupAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CoachData>().ToTable("Coach");
            modelBuilder.Entity<AthleteData>().ToTable("Athlete");
            modelBuilder.Entity<PersonData>().ToTable("Person");
            modelBuilder.Entity<GroupData>().ToTable("Group");
            modelBuilder.Entity<GroupAssignmentData>().ToTable("GroupAssignment").HasKey(g => new { GroupID = g.GroupId, AthleteID = g.AthleteId });
        }
    }
}

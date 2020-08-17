using Chase.DataAccess.Tangible.EntityFrameworkCore.Mapping;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chase.DataAccess.Tangible.EntityFrameworkCore.ContextFile
{
    public class ChaseContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=ChaseDatabase;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Mapler'i tanımlama bölgesi.
            builder.ApplyConfiguration(new DutyMap());
            builder.ApplyConfiguration(new ReportMap());
            builder.ApplyConfiguration(new UrgencyMap());
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new DeclarationMap());
            builder.ApplyConfiguration(new MessageMap());
            base.OnModelCreating(builder);
        }

        public DbSet<Urgency> Urgencies { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Declaration> Declarations { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
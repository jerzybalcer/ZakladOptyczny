using Microsoft.EntityFrameworkCore;
using ZakladOptyczny.Models.Actors;

namespace ZakladOptyczny.Models.Utilities.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>();
            modelBuilder.Entity<Receptionist>();
            modelBuilder.Entity<Optician>();
        }
    }
}

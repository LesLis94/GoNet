//using System.Data.Entity;
using GoNet.BL.Services.Abstract;
using GoNet.Configurations;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;


namespace GoNet.Models
{
    public class DataContext : DbContext
    {

        public DbSet<Players> Players { get; set; }

        public DataContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Casino;Username=postgres;Password=LesLis");
        }


    }
}

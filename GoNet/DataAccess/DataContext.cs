//using System.Data.Entity;
using GoNet.BL.Services.Abstract;
using GoNet.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;


namespace GoNet.DataAccess
{
    public class DataContext : DbContext
    {

        public DbSet<PlayerEntity> Players { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
         {
             // Database.EnsureDeleted();
             //Database.EnsureCreated();
         }
        

        /* public DataContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        } */

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Casino4;Username=postgres;Password=LesLis");
         } */


    }
}

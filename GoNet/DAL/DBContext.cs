//using System.Data.Entity;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using GoNet.BL.Services.Abstract;
using Microsoft.EntityFrameworkCore;


namespace GoNet.DAL
{
    public class DBContext1 : DbContext
    {

        public DbSet<Players> Players { get; set; } = null!;

        public DBContext1()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Casino;Username=postgres;Password=LesLis");
        }

       
    }
}

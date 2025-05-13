using CarvillaMVC.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarvillaMVC.MVC.Contexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<FeaturedCars> featuredCars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WINDOWS-AEJTJIB;Database=FeaturedCarsDb;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using BulkyProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BulkyProject.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
                
        }

        public DbSet<Categories> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryId = 101, Name = "Action", CategoryOrder = 1},
                new Categories { CategoryId = 102, Name = "Sci-Fi", CategoryOrder = 2 },
                new Categories { CategoryId = 103, Name = "Romance", CategoryOrder = 3 },
                new Categories { CategoryId = 104, Name = "Drama", CategoryOrder = 4 });
        }
    }
}

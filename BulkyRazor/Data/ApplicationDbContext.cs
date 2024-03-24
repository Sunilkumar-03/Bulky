using BulkyRazor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BulkyRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CategoryModel> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryId = 101, Name = "Action", CategoryOrder = 1 },
                new CategoryModel { CategoryId = 102, Name = "Sci-Fi", CategoryOrder = 2 },
                new CategoryModel { CategoryId = 103, Name = "Romance", CategoryOrder = 3 },
                new CategoryModel { CategoryId = 104, Name = "Drama", CategoryOrder = 4 });
        }
    }
}

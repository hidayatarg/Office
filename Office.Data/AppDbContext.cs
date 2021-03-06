using Microsoft.EntityFrameworkCore;
using Office.Core.Models;
using Office.Data.Configurations;
using Office.Data.Seeds;

namespace Office.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration Comes Here => Placed in Configuration
            // modelBuilder.Entity<Product>().Property(x => x.Id).UseIdentityColumn();
            // Since We Use Configurations
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
         
            // Apply Seeds
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] {1, 2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] {1, 2}));

            // ** PUT this is Configuration Classes
            // ONLY Added here for learning purpose
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.SurName).HasMaxLength(100);

        }
    }
     
}
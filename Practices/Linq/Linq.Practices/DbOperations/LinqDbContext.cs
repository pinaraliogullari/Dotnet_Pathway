using Linq.Practices.Entities;
using Microsoft.EntityFrameworkCore;

namespace Linq.Practices.DbOperations
{
    public class LinqDbContext : DbContext
    {
   
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "LinqDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Student>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

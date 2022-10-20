using Microsoft.EntityFrameworkCore;
using SyncfusionJavascript.Models;

namespace SyncfusionJavascript.Context
{
    public class SyncfusionDbContext : DbContext
    {
        public SyncfusionDbContext(DbContextOptions<SyncfusionDbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person(1,"Arash", "Mahdipour"),
                new Person(2,"Roya", "Mirzavand"),
                new Person(3,"Seyed", "Ramezani"),
                new Person(4,"Sara", "Gohartoor")
                );
        }
    }
}

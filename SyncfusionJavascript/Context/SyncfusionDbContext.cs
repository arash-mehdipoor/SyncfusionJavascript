using Microsoft.EntityFrameworkCore;
using SyncfusionJavascript.Models;

namespace SyncfusionJavascript.Context
{
    public class SyncfusionDbContext : DbContext
    {
        public SyncfusionDbContext(DbContextOptions<SyncfusionDbContext> options) : base(options)
        {
        }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=syncfusionDB;Integrated Security=true;");
        }
    }
}

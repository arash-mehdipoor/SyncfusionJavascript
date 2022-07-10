using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Domain.Blogs.Entities;
using Zamin.Infra.Data.Sql.Commands;

namespace SampleApp.Infra.Data.Commands
{
    public class SampleAppCommandDbContext : BaseCommandDbContext
    {
        public SampleAppCommandDbContext(DbContextOptions<SampleAppCommandDbContext> options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
    }
}

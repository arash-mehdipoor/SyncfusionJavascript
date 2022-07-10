using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace SampleApp.Infra.Data.Queries
{
    public class SampleAppQueryDbContext : BaseQueryDbContext
    {
        public SampleAppQueryDbContext(DbContextOptions<SampleAppQueryDbContext> options) : base(options)
        {
        }
    }
}

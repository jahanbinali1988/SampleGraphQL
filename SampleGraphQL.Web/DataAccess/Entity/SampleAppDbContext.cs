using Microsoft.EntityFrameworkCore;

namespace SampleGraphQL.Web.DataAccess.Entity
{
    public class SampleAppDbContext : DbContext
    {
        public SampleAppDbContext(DbContextOptions<SampleAppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Department> Department { get; set; }
    }
}
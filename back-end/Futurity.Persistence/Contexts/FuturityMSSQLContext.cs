using Cemiyet.Persistence.Configurations;
using Futurity.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Futurity.Persistence.Contexts
{
    public class FuturityMSSQLContext : DbContext
    {
        public FuturityMSSQLContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}

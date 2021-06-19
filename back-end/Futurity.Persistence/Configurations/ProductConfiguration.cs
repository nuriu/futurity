using Futurity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cemiyet.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductID);

            builder.Property(p => p.ProductName)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.Property(p => p.ProductDescription)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.UnitsInStock).IsRequired();
        }
    }
}

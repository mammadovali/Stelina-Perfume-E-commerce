using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stelina.Domain.Models.Entities;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class ProductRateEntityTypeConfiguration : IEntityTypeConfiguration<ProductRate>
    {
        public void Configure(EntityTypeBuilder<ProductRate> builder)
        {
            builder.HasKey(key =>
            new
            {
                key.ProductId,
                key.CreatedByUserId
            });

            builder.ToTable("ProductRates");
        }
    }
}

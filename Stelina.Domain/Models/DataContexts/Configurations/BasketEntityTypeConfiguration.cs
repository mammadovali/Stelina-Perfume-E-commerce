using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stelina.Domain.Models.Entities;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class BasketEntityTypeConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(k => new
            {
                k.UserId,
                k.ProductId
            });

            builder.ToTable("Basket");
        }
    }
}

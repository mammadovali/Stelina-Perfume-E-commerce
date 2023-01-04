using Stelina.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class StelinaUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<StelinaUserToken>
    {
        public void Configure(EntityTypeBuilder<StelinaUserToken> builder)
        {
            builder.ToTable("UserTokens", "Membership");
        }
    }
}

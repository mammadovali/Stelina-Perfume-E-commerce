using Stelina.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class StelinaUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<StelinaUserClaim>
    {
        public void Configure(EntityTypeBuilder<StelinaUserClaim> builder)
        {
            builder.ToTable("UserClaims", "Membership");
        }
    }
}

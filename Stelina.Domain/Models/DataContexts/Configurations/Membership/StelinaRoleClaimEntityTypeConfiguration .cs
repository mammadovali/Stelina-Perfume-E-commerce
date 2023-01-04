using Stelina.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class StelinaRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<StelinaRoleClaim>
    {
        public void Configure(EntityTypeBuilder<StelinaRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}

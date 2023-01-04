using Stelina.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class StelinaRoleEntityTypeConfiguration : IEntityTypeConfiguration<StelinaRole>
    {
        public void Configure(EntityTypeBuilder<StelinaRole> builder)
        {
            builder.ToTable("Roles", "Membership");
        }
    }
}

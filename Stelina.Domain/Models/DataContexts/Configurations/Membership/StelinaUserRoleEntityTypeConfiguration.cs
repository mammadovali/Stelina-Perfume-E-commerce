using Stelina.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class StelinaUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<StelinaUserRole>
    {
        public void Configure(EntityTypeBuilder<StelinaUserRole> builder)
        {
            builder.ToTable("UserRole", "Membership");
        }
    }
}

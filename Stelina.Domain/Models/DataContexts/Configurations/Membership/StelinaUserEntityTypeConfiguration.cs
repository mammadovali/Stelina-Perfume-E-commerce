using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stelina.Domain.Models.Entities.Membership;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class StelinaUserEntityTypeConfiguration : IEntityTypeConfiguration<StelinaUser>
    {
        public void Configure(EntityTypeBuilder<StelinaUser> builder)
        {
            builder.ToTable("Users", "Membership");
        }
    }
}

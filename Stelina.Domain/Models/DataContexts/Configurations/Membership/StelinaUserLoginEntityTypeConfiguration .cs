using Stelina.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class StelinaUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<StelinaUserLogin>
    {
        public void Configure(EntityTypeBuilder<StelinaUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}

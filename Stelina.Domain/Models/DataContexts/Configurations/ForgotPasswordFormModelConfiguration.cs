using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stelina.Domain.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.DataContexts.Configurations
{
    public class ForgotPasswordFormModelConfiguration : IEntityTypeConfiguration<ForgotPasswordFormModel>
    {
        public void Configure(EntityTypeBuilder<ForgotPasswordFormModel> builder)
        {
            builder.HasKey(x => x.Email);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("Email")
                .HasColumnType("varchar(256)");
        }
    }

}

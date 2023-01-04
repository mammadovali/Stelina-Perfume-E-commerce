using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.Entities;
using Stelina.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.DataContexts
{
    public class StelinaDbContext : IdentityDbContext<StelinaUser, StelinaRole, int, StelinaUserClaim,
        StelinaUserRole, StelinaUserLogin, StelinaRoleClaim, StelinaUserToken>
    {
        public StelinaDbContext(DbContextOptions option)
            : base(option)
        {

        }

        public DbSet<ContactPost> ContactPosts { get; set; }

        public DbSet<ContactDetail> ContactDetails { get; set; }

        public DbSet<Faq> Faqs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StelinaDbContext).Assembly);
        }

    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stelina.Domain.Models.Entities.Membership;
using System;

namespace Stelina.Domain.Models.DataContexts
{
    public static class StelinaDbSeed
    {
        public static IApplicationBuilder SeedMembership(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<StelinaUser>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<StelinaUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<StelinaRole>>();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                string superAdminRoleName = configuration["defaultAccount:superAdmin"];
                string superAdminEmail = configuration["defaultAccount:email"];
                string superAdminUserName = configuration["defaultAccount:username"];
                string superAdminPassword = configuration["defaultAccount:password"];
                string superAdminName = configuration["defaultAccount:name"];
                string superAdminSurname = configuration["defaultAccount:surname"];

                var superAdminRole = roleManager.FindByNameAsync(superAdminRoleName).Result;


                if (superAdminRole == null)
                {
                    superAdminRole = new StelinaRole
                    {
                        Name = superAdminRoleName,
                    };

                    var roleResult = roleManager.CreateAsync(superAdminRole).Result;

                    if (!roleResult.Succeeded)
                    {
                        throw new Exception("Rol yaradılmasında problem yaşandı...");
                    }
                }

                var superAdminUser = userManager.FindByEmailAsync(superAdminEmail).Result;

                if (superAdminUser == null)
                {
                    superAdminUser = new StelinaUser
                    {
                        Email = superAdminEmail,
                        UserName = superAdminUserName,
                        EmailConfirmed = true,
                        Name = superAdminName,
                        Surname = superAdminSurname
                    };

                    var userResult = userManager.CreateAsync(superAdminUser, superAdminPassword).Result;

                    if (!userResult.Succeeded)
                    {
                        throw new Exception("İstifadəçinin yaradılmasında problem yaşandı...");
                    }
                }

                var isInRole = userManager.IsInRoleAsync(superAdminUser, superAdminRole.Name).Result;

                if (isInRole != true)
                {
                    userManager.AddToRoleAsync(superAdminUser, superAdminRole.Name).Wait();
                }

            }

            return app;
        }

        public static void SeedUserRole(RoleManager<StelinaRole> roleManager)
        {

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                StelinaRole role = new StelinaRole();
                role.Name = "User";

                IdentityResult roleResult = roleManager.

                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Moderator").Result)
            {
                StelinaRole role = new StelinaRole();
                role.Name = "Moderator";

                IdentityResult roleResult = roleManager.

                CreateAsync(role).Result;
            }

        }
    }
}
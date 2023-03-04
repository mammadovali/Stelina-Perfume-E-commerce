using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Stelina.Domain.AppCode.Behaviors;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.AppCode.Providers;
using Stelina.Domain.AppCode.Services;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities.Membership;
using System;
using System.Linq;

namespace Stelina.WebUI
{
    public class Startup
    {

        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;   // json file larini oxuya bilmek uchun
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(
                cfg =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                    cfg.Filters.Add(new AuthorizeFilter(policy));
                    cfg.ModelBinderProviders.Insert(0, new BooleanBinderProvider());
                }
            ).AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
           

            services.AddDbContext<StelinaDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration["ConnectionStrings:cString"]);
            });

            services.AddIdentity<StelinaUser, StelinaRole>()
                .AddEntityFrameworkStores<StelinaDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true; //herkesin bir emaili olsun
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredUniqueChars = 1; //123
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 1, 0);
                cfg.Lockout.MaxFailedAccessAttempts = 30;
                cfg.Password.RequiredLength = 3;

                cfg.User.RequireUniqueEmail = true;

                cfg.SignIn.RequireConfirmedEmail = true;

            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/notfound.html";

                cfg.Cookie.Name = "stelina";
                cfg.Cookie.HttpOnly = true;
                cfg.ExpireTimeSpan = new TimeSpan(0, 45, 0);
            });

            services.AddAuthentication();
            services.AddAuthorization(cfg =>
            {

                foreach (var policyName in Extension.policies)
                {
                    cfg.AddPolicy(policyName, p =>
                    {
                        p.RequireAssertion(handler =>
                        {
                            return handler.User.IsInRole("SuperAdmin") ||
                            handler.User.HasClaim(policyName, "1");
                        });
                    });

                }
            });

            services.AddScoped<UserManager<StelinaUser>>();
            services.AddScoped<SignInManager<StelinaUser>>();
            services.AddScoped<RoleManager<StelinaRole>>();


            services.AddRouting(cfg =>    // url lerin kichik herfle gorunmesi uchun
            {
                cfg.LowercaseUrls = true;
            });

            services.Configure<EmailServiceOptions>(cfg =>
            {
                configuration.GetSection("emailAccount").Bind(cfg);
            });

            services.AddSingleton<EmailService>();

            services.AddSingleton<CryptyoService>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Stelina."));

            services.AddMediatR(assemblies.ToArray());

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LogBehavior<,>));

            services.AddScoped<IClaimsTransformation, AppClaimProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<StelinaRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.SeedMembership();
            StelinaDbSeed.SeedUserRole(roleManager);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute(
                name: "default-accessdenied",
                pattern: "accessdenied.html",
                defaults: new
                {
                    area = "",
                    controller = "account",
                    action = "accessdenied"
                });

                cfg.MapAreaControllerRoute("defaultAdmin", "admin", "admin/{controller=account}/{action=signin}/{id?}");  // for admin panel
                cfg.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

            });
        }
    }
}

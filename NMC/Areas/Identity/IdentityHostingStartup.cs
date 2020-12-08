using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NMC.Infrastructure;
using NMC.Domain.Models;
using NMC.Core;

[assembly: HostingStartup(typeof(NMC.Areas.Identity.IdentityHostingStartup))]
namespace NMC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContextPool<MedContext>(options =>
                    // options.UseSqlServer(context.Configuration.GetConnectionString("MedContextConnection"))
                    options.UseNpgsql(context.Configuration.GetConnectionString("Med"))
                    ) ;

                services.AddDefaultIdentity<AppUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddRoles<AppRole>()
                    .AddEntityFrameworkStores<MedContext>();
            });
        }
    }
}
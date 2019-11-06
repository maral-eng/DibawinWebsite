using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.ClassLibraries.Authentication;

[assembly: HostingStartup(typeof(DibawinWebsite.Areas.Identity.IdentityHostingStartup))]
namespace DibawinWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MyDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MyDBContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<MyDBContext>()
                    .AddDefaultTokenProviders();
            });
        }
    }
}
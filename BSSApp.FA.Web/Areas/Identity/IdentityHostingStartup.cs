using System;
using BSSApp.FA.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BSSApp.FA.Web.Areas.Identity.IdentityHostingStartup))]
namespace BSSApp.FA.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BSSAppFAWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BSSAppFAWebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BSSAppFAWebContext>();
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSSApp.FA.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace BSSApp.FA.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddScoped<IAcMasterRepository, AcMasterRepository>();
            services.AddScoped<ILedgerRepository, LedgerRepository>();
            services.AddScoped<ISubLedgerRepository, SubLedgerRepository>();
            services.AddScoped<IAccountGroupMasterRepository, AccountGroupMasterRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ITypeMastRepository, TypeMastRepository>();
            services.AddScoped<IBSheetGroupRepository, BSheetGroupRepository>();
            services.AddScoped<ICostCenterRepository, CostCenterRepository>();
            services.AddScoped<IUserObjectAssignMasterRepository, UserObjectAssignMasterRepository>();
            services.AddScoped<IModuleObjectMasterRepository, ModuleObjectMasterRepository>();

            services.AddRazorPages();
            services.AddControllers();
            services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddControllers(options =>
            {
                options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
            });

        }
        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

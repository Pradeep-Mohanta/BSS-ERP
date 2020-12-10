using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blazored.Modal;

namespace BSSApp.FA.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredModal();
            services.AddHttpClient<IAcMasterService, AcMasterService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<ILedgerService, LedgerService>(client => {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<ISubLedgerService, SubLedgerService>(client => {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<IAccountGroupMasterService, AccountGroupMasterService>(client => {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<ICountryService, CountryService>(client => {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<IStateService, StateService>(client => {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<ITypeMastService, TypeMastService>(client=> {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<IBSheetGroupService, BSheetGroupService>(client => {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<ICostCenterService, CostCenterService>(client => {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<IUserAssignModuleService, UserAssignModuleService>(client => {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<IModuleObjectMasterService, ModuleObjectMasterService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<ITrnService, TrnService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<IBookMasterService, BookMasterService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
            services.AddHttpClient<ITrnMemoService, TrnMemoService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

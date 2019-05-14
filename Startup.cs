using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Transdim.DomainModel.GameComponents.PowerActions;
using Transdim.Persistence;
using Transdim.Service;
using Transdim.Shared;
using Transdim.Utilities;

namespace Transdim
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // 1st party
            services.AddScoped<SetupNavigationUtility>();
            services.AddTransdimService();
            services.AddTransdimPersistence();

            // 3rd party
            services.AddBlazoredModal();

            var serviceProvider = services.BuildServiceProvider();

            // gameComponents
            AddGameComponents(services, serviceProvider);
        }

        private void AddGameComponents(IServiceCollection services, IServiceProvider serviceProvider)
        {
            services.AddSingleton(new PointsForPlanetsQicAction(serviceProvider.GetRequiredService<IModalService>(), typeof(PointsModal)));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Transdim.Service;
using Transdim.Persistence;
using Transdim.Utilities;
using Blazored.Modal;
using System;
using Transdim.DomainModel.GameComponents.PowerActions;
using Blazored.Modal.Services;
using Transdim.Shared;

namespace Transdim
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 1st party
            services.AddSingleton<SetupNavigationUtility>();
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

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}

using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Transdim.Service;
using Transdim.Persistence;
using Transdim.Utilities;
using Blazored.Modal;

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
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}

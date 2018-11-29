using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Transdim.Service;
using Transdim.Persistence;
using Transdim.Utilities;

namespace Transdim
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SetupNavigationUtility>();
            services.AddTransdimService();
            services.AddTransdimPersistence();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}

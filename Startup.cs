using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Transdim.Service;

namespace Transdim
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services.AddTransdimService();

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}

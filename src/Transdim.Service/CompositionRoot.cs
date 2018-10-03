using Microsoft.Extensions.DependencyInjection;
using System;
using Transdim.Service.Internal;

namespace Transdim.Service
{
    public static class CompositionRoot
    {
        public static void AddTransdimService(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<IGameStateService, GameStateService>();
        }
    }
}

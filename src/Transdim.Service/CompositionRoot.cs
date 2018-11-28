using System;
using Microsoft.Extensions.DependencyInjection;
using Transdim.Service.Internal;
using Transdim.Service.Internal.Controllers;
using Transdim.Service.Internal.Services;

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

            // Controllers
            services.AddTransient<INewGameController, NewGameController>();

            // Services
            services.AddSingleton<IGameStateService, GameStateService>();
            services.AddSingleton<IFactionService, FactionService>();
        }
    }
}

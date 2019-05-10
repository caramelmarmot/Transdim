using System;
using Microsoft.Extensions.DependencyInjection;
using Transdim.Service.Internal.Controllers;
using Transdim.Service.Internal.Controllers.Setup.Tech;
using Transdim.Service.Internal.Controllers.Setup.Board;
using Transdim.Service.Internal.Helpers;
using Transdim.Service.Internal.Services;
using Transdim.Service.Internal.Controllers.NewGame;
using Transdim.Service.Internal.Controllers.CurrentGame;
using Transdim.Service.Internal.Controllers.Shared;

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
            services.AddTransient<IBoardSetupController, BoardSetupController>();
            services.AddTransient<ITechSetupController, TechSetupController>();
            services.AddTransient<IBaseGameController, BaseGameController>();
            services.AddTransient<IGameLogController, GameLogController>();
            services.AddTransient<IGameComponentController, GameComponentController>();

            // Services
            services.AddSingleton<IGameInitializationService, GameInitializationService>();
            services.AddSingleton<IGameStateService, GameStateService>();
            services.AddSingleton<IFactionService, FactionService>();

            // Helpers
            services.AddSingleton<IRandomizerFactory, RandomizerFactory>();
        }
    }
}

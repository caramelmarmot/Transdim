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
using Transdim.Service.Internal.Services.Modal;

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

            // Services
            services.AddScoped<IGameInitializationService, GameInitializationService>();
            services.AddScoped<IGameStateService, GameStateService>();
            services.AddScoped<IFactionService, FactionService>();
            services.AddScoped<IUiQueueService, UiQueueService>();
            services.AddScoped<IGameComponentController, GameComponentController>();
            services.AddScoped<IModalService, ModalService>();

            // Helpers
            services.AddScoped<IRandomizerFactory, RandomizerFactory>();
        }
    }
}

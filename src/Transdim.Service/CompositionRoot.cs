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
using Transdim.Service.Internal.ComponentActivators;
using System.Collections.Generic;
using Transdim.Service.Internal.ComponentActivators.Actions;
using Transdim.Service.Internal.ComponentActivators.Scorers;

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
            services.AddScoped<IQueueManagementService, QueueManagementService>();
            services.AddScoped<IQueueExecutionService, QueueExecutionService>();
            services.AddScoped<IGameComponentController, GameComponentController>();
            services.AddScoped<IModalService, ModalService>();
            services.AddScoped<IScoreAnimationService, ScoreAnimationService>();

            // Helpers
            services.AddScoped<IRandomizerFactory, RandomizerFactory>();

            // ComponentActivators
            AddComponentActivators(services);
        }

        private static void AddComponentActivators(IServiceCollection services)
        {
            var componentList = new List<IComponentActivator> { };

            // Actions
            services.AddScoped<PowerActionTaker>();

            // Scorers
            services.AddScoped<AdjustiblePointScorer>();

            // Ordering matters! They'll execute in the order they're registered.
            services.AddScoped<IComponentActivator>(sc =>
                new CompositeComponentActivator(
                    new List<IComponentActivator>
                    {
                        // Actions
                        sc.GetRequiredService<PowerActionTaker>(),

                        // Scorers
                        sc.GetRequiredService<AdjustiblePointScorer>(),
                    }));
        }
    }
}

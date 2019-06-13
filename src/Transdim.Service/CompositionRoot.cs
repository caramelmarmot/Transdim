using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Transdim.Service.ComponentActivators.Actions;
using Transdim.Service.ComponentActivators.Scorers;
using Transdim.Service.ComponentActivators;
using Transdim.Service.Controllers.CurrentGame;
using Transdim.Service.Controllers.NewGame;
using Transdim.Service.Controllers.Setup.Board;
using Transdim.Service.Controllers.Setup.Tech;
using Transdim.Service.Controllers.Shared;
using Transdim.Service.Controllers;
using Transdim.Service.Helpers;
using Transdim.Service.Services.Modal;
using Transdim.Service.Services;

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

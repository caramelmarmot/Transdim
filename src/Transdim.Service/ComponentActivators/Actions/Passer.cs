using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;
using Transdim.Service.Services;

namespace Transdim.Service.ComponentActivators.Actions
{
    internal class Passer : IComponentActivator
    {
        private readonly IQueueManagementService queueManagementService;
        private readonly IGameStateService gameStateService;

        public Passer(IQueueManagementService queueManagementService, IGameStateService gameStateService)
        {
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
        }

        public void Activate(IGameComponent component)
        {
            if (!(component is IPasser))
            {
                return;
            }

            queueManagementService.AddImmediate(new GameEvent { EventToPerform = () => { gameStateService.LogAction("passed.", default, default, true); } });
            queueManagementService.AddImmediate(new GameEvent { EventToPerform = () => { gameStateService.ScoreOnPass(); } });
            queueManagementService.AddFinal(new GameEvent { EventToPerform = () => { gameStateService.Pass(); } });
            queueManagementService.AddFinal(new GameEvent { EventToPerform = () => { gameStateService.EndTurn(); } });

            queueManagementService.Execute();
        }
    }
}

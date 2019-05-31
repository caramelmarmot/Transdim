using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.Service.Internal.ComponentActivators.Actions
{
    internal class PowerActionTaker : IComponentActivator
    {
        private readonly IQueueManagementService queueManagementService;
        private readonly IQueueExecutionService queueExecutionService;
        private readonly IGameStateService gameStateService;

        public PowerActionTaker(IQueueManagementService queueManagementService, IQueueExecutionService queueExecutionService, IGameStateService gameStateService)
        {
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
            this.queueExecutionService = queueExecutionService ?? throw new ArgumentNullException(nameof(queueExecutionService));
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
        }

        public void Activate(IGameComponent component)
        {
            if (!(component is IPowerActionTaker))
            {
                return;
            }

            queueManagementService.Add(new UiModalEvent("Power action", ModalIdentifier.PowerAction));
            queueManagementService.AddFinal(new GameUpdateEvent { EventToPerform = () => { gameStateService.EndTurn(); } });
            queueExecutionService.Execute();
            
            // TODO: manage game state
        }
    }
}

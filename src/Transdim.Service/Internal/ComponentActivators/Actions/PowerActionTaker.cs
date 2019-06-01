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

            var activePlayer = gameStateService.GetActivePlayer();

            var actionPerformed = new GameAction
            {
                IsUndoCheckpoint = true,
                Player = activePlayer,
                LogText = $"{activePlayer.Faction.FriendlyName} took a power action...",
                Points = 0
            };

            queueManagementService.AddImmediate(new GameUpdateEvent { EventToPerform = () => { gameStateService.AddAction(actionPerformed); } });

            queueManagementService.Add(new UiModalEvent("Power action", ModalIdentifier.PowerAction));

            queueManagementService.AddFinal(new GameUpdateEvent { EventToPerform = () => { gameStateService.EndTurn(); } });

            queueExecutionService.Execute();
        }
    }
}

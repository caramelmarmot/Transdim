using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;
using Transdim.Service.Services;

namespace Transdim.Service.ComponentActivators.Actions
{
    internal class PowerActionTaker : IComponentActivator
    {
        private readonly IQueueManagementService queueManagementService;
        private readonly IGameStateService gameStateService;

        public PowerActionTaker(IQueueManagementService queueManagementService, IGameStateService gameStateService)
        {
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
        }

        public void Activate(IGameComponent component)
        {
            if (!(component is IPowerActionTaker))
            {
                return;
            }

            queueManagementService.AddImmediate(new GameEvent
            {
                EventToPerform = () =>
                {
                    gameStateService.LogAction("took a power action", default, default, true);
                }
            });
            queueManagementService.Add(new UiModalEvent("Power action", ModalIdentifier.PowerActionPicker));
            queueManagementService.AddFinal(new GameEvent { EventToPerform = () => { gameStateService.EndTurn(); } });

            queueManagementService.Execute();
        }
    }
}

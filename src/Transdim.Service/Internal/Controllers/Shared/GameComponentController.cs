using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.Service.Internal.Controllers.Shared
{
    internal class GameComponentController : IGameComponentController
    {
        private readonly IQueueManagementService queueManagementService;
        private readonly IQueueExecutionService queueExecutionService;

        public GameComponentController(IQueueManagementService queueManagementService, IQueueExecutionService queueExecutionService)
        {
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
            this.queueExecutionService = queueExecutionService ?? throw new ArgumentNullException(nameof(queueExecutionService));
        }

        public void Activate(IGameComponent component)
        {
            // TODO: Extract these into injected classes. Or a composite?
            if (component is IPowerActionTaker)
            {
                queueManagementService.Add(new UiModalEvent("Power action", ModalIdentifier.PowerAction));
                queueExecutionService.Execute();
            }
            if (component is IAdjustablePointsScorer)
            {
                queueManagementService.Add(new UiModalEvent("Choose number of points", ModalIdentifier.AdjustablePointsScorer));
                queueManagementService.Add(new UiComponentScoringEvent(GameComponents.PowerActionQicPointsForPlanets, 0));
                queueManagementService.Add(new UiComponentScoringEvent(GameComponents.ActionPowerAction, 0));
                queueExecutionService.Execute();
            }
        }
    }
}

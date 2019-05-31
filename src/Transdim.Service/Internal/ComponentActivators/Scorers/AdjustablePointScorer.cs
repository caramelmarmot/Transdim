using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.Service.Internal.ComponentActivators.Scorers
{
    internal class AdjustiblePointScorer : IComponentActivator
    {
        private readonly IQueueManagementService queueManagementService;
        private readonly IQueueExecutionService queueExecutionService;
        private readonly IGameStateService gameStateService;

        public AdjustiblePointScorer(IQueueManagementService queueManagementService, IQueueExecutionService queueExecutionService, IGameStateService gameStateService)
        {
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
            this.queueExecutionService = queueExecutionService ?? throw new ArgumentNullException(nameof(queueExecutionService));
            this.gameStateService = gameStateService ?? throw new ArgumentNullException(nameof(gameStateService));
        }

        public void Activate(IGameComponent component)
        {
            if (!(component is IAdjustablePointsScorer))
            {
                return;
            }

            queueManagementService.Add(new UiModalEvent("Choose number of points", ModalIdentifier.AdjustablePointsScorer));
            queueManagementService.Add(new UiComponentScoringEvent(GameComponents.PowerActionQicPointsForPlanets, 0));
            queueManagementService.Add(new UiComponentScoringEvent(GameComponents.ActionPowerAction, 0));
            queueExecutionService.Execute();

            // TODO: manage game state
        }
    }
}

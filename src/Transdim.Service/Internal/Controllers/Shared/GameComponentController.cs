using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.Service.Internal.Controllers.Shared
{
    internal class GameComponentController : IGameComponentController
    {
        private readonly IQueueManagementService queueManagementService;

        public GameComponentController(IQueueManagementService queueManagementService)
        {
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
        }

        public void Activate(IGameComponent component)
        {
            // TODO: Extract these into injected classes. Or a composite?
            if (component is IPowerActionTaker)
            {
                queueManagementService.Add(new UiModalEvent("Power action", ModalIdentifier.PowerAction));
            }
            if (component is IAdjustablePointsScorer)
            {
                queueManagementService.Add(new UiModalEvent("Choose number of points", ModalIdentifier.AdjustablePointsScorer));
                queueManagementService.Add(new UiComponentScoringEvent(GameComponents.PowerActionQicPointsForPlanets, 0));
                queueManagementService.Add(new UiComponentScoringEvent(GameComponents.ActionPowerAction, 0));
            }
        }
    }
}

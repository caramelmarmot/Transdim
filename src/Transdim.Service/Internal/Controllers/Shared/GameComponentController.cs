using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.Service.Internal.Controllers.Shared
{
    internal class GameComponentController : IGameComponentController
    {
        private readonly IUiQueueService uiQueueService;

        public GameComponentController(IUiQueueService uiQueueService)
        {
            this.uiQueueService = uiQueueService ?? throw new ArgumentNullException(nameof(uiQueueService));
        }

        public void Activate(IGameComponent component)
        {
            // TODO: Extract these into injected classes. Or a composite?
            if (component is IPowerActionTaker)
            {
                uiQueueService.Add(new UiModalEvent("Power action", ModalIdentifier.PowerAction));
            }
            if (component is IAdjustablePointsScorer)
            {
                uiQueueService.Add(new UiModalEvent("Choose number of points", ModalIdentifier.AdjustablePointsScorer));
                uiQueueService.Add(new UiComponentScoringEvent(GameComponents.PowerActionQicPointsForPlanets, 0));
                uiQueueService.Add(new UiComponentScoringEvent(GameComponents.ActionPowerAction, 0));
            }
        }
    }
}

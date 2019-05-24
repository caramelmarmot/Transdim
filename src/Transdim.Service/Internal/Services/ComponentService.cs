using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.Service.Internal.Services
{
    internal class ComponentService : IComponentService
    {
        private readonly IUiQueueService uiQueueService;

        public ComponentService(IUiQueueService uiQueueService)
        {
            this.uiQueueService = uiQueueService ?? throw new ArgumentNullException(nameof(uiQueueService));
        }

        public void Activate(IGameComponent component)
        {
            // TODO: Extract these into injected classes. Or a composite?
            if (component is IPowerActionTaker)
            {
                uiQueueService.Add(new UiEvent("Power action", Modal.PowerAction));
            }
            if (component is IAdjustablePointsScorer)
            {
                uiQueueService.Add(new UiEvent("Choose number of points", Modal.AdjustablePointsScorer));
            }
        }
    }
}

using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.Service.Internal.Services
{
    internal class ComponentActivationService : IComponentActivationService
    {
        private readonly IUiQueueService uiQueueService;

        public ComponentActivationService(IUiQueueService uiQueueService)
        {
            this.uiQueueService = uiQueueService ?? throw new ArgumentNullException(nameof(uiQueueService));
        }

        public void Activate(IGameComponent component)
        {
            // TODO: Extract these into injected classes
            if (component is IAdjustablePointsScorer) {
                uiQueueService.Add(new UiEvent { Title = "Choose number of points", ModalToShow = Modal.AdjustablePointsScorer });
            }
            if (component is IPowerActionTaker)
            {
                uiQueueService.Add(new UiEvent { Title = "Power action", ModalToShow = Modal.PowerAction });
            }
        }
    }
}

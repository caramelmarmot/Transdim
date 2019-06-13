using System;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents;
using Transdim.DomainModel.GameComponents.Interfaces;
using Transdim.Service.Services;

namespace Transdim.Service.ComponentActivators.Scorers
{
    internal class AdjustiblePointScorer : IComponentActivator
    {
        private readonly IQueueManagementService queueManagementService;

        public AdjustiblePointScorer(IQueueManagementService queueManagementService)
        {
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
        }

        public void Activate(IGameComponent component)
        {
            if (!(component is IAdjustablePointsScorer))
            {
                return;
            }

            queueManagementService.Add(new UiModalEvent(string.Empty, ModalIdentifier.AdjustablePointsScorer, new ModalParameters(nameof(IGameComponent), component)));
            queueManagementService.Execute();
        }
    }
}

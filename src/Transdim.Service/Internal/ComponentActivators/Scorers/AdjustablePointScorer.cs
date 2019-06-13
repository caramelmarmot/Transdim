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

        public AdjustiblePointScorer(IQueueManagementService queueManagementService, IQueueExecutionService queueExecutionService)
        {
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
            this.queueExecutionService = queueExecutionService ?? throw new ArgumentNullException(nameof(queueExecutionService));
        }

        public void Activate(IGameComponent component)
        {
            if (!(component is IAdjustablePointsScorer))
            {
                return;
            }

            queueManagementService.Add(new UiModalEvent(string.Empty, ModalIdentifier.AdjustablePointsScorer, new ModalParameters(nameof(IGameComponent), component)));
            queueExecutionService.Execute();
        }
    }
}

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

            var adjustiblePoiontScorerParameters = new ModalParameters();
            adjustiblePoiontScorerParameters.Add(nameof(IGameComponent), component);
            queueManagementService.Add(new UiModalEvent("Choose number of points", ModalIdentifier.AdjustablePointsScorer, adjustiblePoiontScorerParameters));
            queueExecutionService.Execute();

            // TODO: manage game state
        }
    }
}

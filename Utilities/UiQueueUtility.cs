using System;
using Transdim.DomainModel;
using Transdim.Service;

namespace Transdim.Utilities
{
    public class UiQueueUtility
    {
        private readonly IQueueManagementService uiQueueService;
        private readonly IModalService modalService;
        private readonly UiComponentScoringUtility uiComponentScoringUtility;

        private bool currentlyExecuting = false;

        public UiQueueUtility(IQueueManagementService uiQueueService, IModalService modalService, UiComponentScoringUtility uiComponentScoringUtility) {
            this.uiQueueService = uiQueueService ?? throw new ArgumentNullException(nameof(uiQueueService));
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
            this.uiComponentScoringUtility = uiComponentScoringUtility ?? throw new ArgumentNullException(nameof(uiComponentScoringUtility));
        }

        public void Add(IUiEvent uiEventToAdd) =>
            uiQueueService.Add(uiEventToAdd);

        public void Execute()
        {
            if (currentlyExecuting)
            {
                return;
            }

            var itemToProcess = uiQueueService.GetNextEvent();

            if (itemToProcess == null)
            {
                return;
            }

            currentlyExecuting = true;

            if (itemToProcess is IUiModalEvent modalToProcess)
            {
                modalService.OnClose += ProcessNext;

                modalService.Show(modalToProcess.Title, modalToProcess.ModalIdentifier);
            }
            else if (itemToProcess is IUiComponentScoringEvent componentScoringToProcess)
            {
                uiComponentScoringUtility.OnFinishAnimation += ProcessNext;
                uiComponentScoringUtility.Score(componentScoringToProcess.GameComponent, componentScoringToProcess.Points);
            }
        }

        private void ProcessNext(ModalResult modalResult)
        {
            modalService.OnClose -= ProcessNext;
            ProcessNext();
        }

        private void ProcessNext()
        {
            uiComponentScoringUtility.OnFinishAnimation -= ProcessNext;
            currentlyExecuting = false;

            Execute();
        }
    }
}

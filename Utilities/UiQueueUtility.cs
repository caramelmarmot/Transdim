using System;
using System.Collections.Generic;
using Transdim.DomainModel;
using Transdim.DomainModel.GameComponents.PowerActions;
using Transdim.Pages.CurrentGame.ActionPanel.PowerAction.Modal;
using Transdim.Service;
using Transdim.Shared;

namespace Transdim.Utilities
{
    public class UiQueueUtility
    {
        private readonly IUiQueueService uiQueueService;
        private readonly IModalService modalService;
        private readonly UiComponentScoringUtility uiComponentScoringUtility;

        private bool IsModalOpen = false;
        private bool IsAnimating = false;

        private Dictionary<ModalIdentifier, Type> ModalMapping = new Dictionary<ModalIdentifier, Type>()
        {
            // TODO: rename PointsModal
            { ModalIdentifier.AdjustablePointsScorer, typeof(PointsModal)},
            { ModalIdentifier.PowerAction, typeof(PowerActionModal)}
        };

        public UiQueueUtility(IUiQueueService uiQueueService, IModalService modalService, UiComponentScoringUtility uiComponentScoringUtility) {
            this.uiQueueService = uiQueueService ?? throw new ArgumentNullException(nameof(uiQueueService));
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
            this.uiComponentScoringUtility = uiComponentScoringUtility ?? throw new ArgumentNullException(nameof(uiComponentScoringUtility));
        }

        public void Add(IUiEvent uiEventToAdd) =>
            uiQueueService.Add(uiEventToAdd);

        public void Execute()
        {
            if (IsModalOpen)
            {
                // Close the modal. The modal's OnClose event will execute the next UI event.
                modalService.Close(ModalResult.Ok(true));
                return;
            }

            if (IsAnimating)
            {
                // Finish the animation. The OnFinishAnimation event will execute the next event.
                uiComponentScoringUtility.FinishAnimation();
                return;
            }

            var itemToProcess = uiQueueService.GetNextEvent();

            if (itemToProcess == null)
            {
                return;
            }

            if (itemToProcess is IUiModalEvent modalToProcess)
            {
                if (!ModalMapping.TryGetValue(modalToProcess.ModalToShow, out var modalToShow))
                {
                    throw new ArgumentNullException(nameof(modalToProcess.ModalToShow));
                }

                IsModalOpen = true;
                modalService.OnClose += ProcessNextItemFromQueue;

                uiQueueService.RegisterEventTaken();
                modalService.Show(modalToProcess.Title, modalToShow);
            }
            else if (itemToProcess is IUiComponentScoringEvent componentScoringToProcess)
            {
                IsAnimating = true;
                uiComponentScoringUtility.Score(componentScoringToProcess.GameComponent, componentScoringToProcess.Points);
                uiComponentScoringUtility.OnFinishAnimation += ProcessNextItemFromQueue;
            }
        }

        private void ProcessNextItemFromQueue(ModalResult modalResult)
        {
            modalService.OnClose -= ProcessNextItemFromQueue;
            uiComponentScoringUtility.OnFinishAnimation -= ProcessNextItemFromQueue;

            IsModalOpen = false;
            IsAnimating = false;
            Execute();
        }
    }
}

using Blazored.Modal.Services;
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

        private bool IsExecuting = false;

        private Dictionary<Modal, Type> ModalMapping = new Dictionary<Modal, Type>()
        {
            // TODO: rename PointsModal
            { Modal.AdjustablePointsScorer, typeof(PointsModal)},
            { Modal.PowerAction, typeof(PowerActionModal)}
        };

        public UiQueueUtility(IUiQueueService uiQueueService, IModalService modalService, UiComponentScoringUtility uiComponentScoringUtility) {
            this.uiQueueService = uiQueueService ?? throw new ArgumentNullException(nameof(uiQueueService));
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
            this.uiComponentScoringUtility = uiComponentScoringUtility ?? throw new ArgumentNullException(nameof(uiComponentScoringUtility));
        }

        public void Add(UiEvent uiEventToAdd) =>
            uiQueueService.Add(uiEventToAdd);

        public void Execute()
        {
            if (IsExecuting)
            {
                modalService.Close(ModalResult.Ok(true));
                return;
            }

            var itemToProcess = uiQueueService.GetNextEvent();

            if (itemToProcess == null)
            {
                // TODO: Just an example of this working. Remove.
                // uiComponentScoringUtility.Score(new QicPointsForPlanets(), 2);
                return;
            }

            if (!ModalMapping.TryGetValue(itemToProcess.ModalToShow, out var modalToShow))
            {
                throw new ArgumentNullException(nameof(itemToProcess.ModalToShow));
            }

            IsExecuting = true;
            modalService.OnClose += ProcessNextItemFromQueue;

            uiQueueService.RegisterEventTaken();
            modalService.Show(itemToProcess.Title, modalToShow);
        }

        private void ProcessNextItemFromQueue(ModalResult modalResult)
        {
            IsExecuting = false;
            modalService.OnClose -= ProcessNextItemFromQueue;
            Execute();
        }
    }
}

using Blazored.Modal.Services;
using System;
using System.Collections.Generic;
using Transdim.DomainModel;
using Transdim.Pages.CurrentGame.ActionPanel.PowerAction.Modal;
using Transdim.Service;
using Transdim.Shared;

namespace Transdim.Utilities
{
    public class UiQueueExecutor
    {
        private readonly IUiQueueService uiQueueService;
        private readonly IModalService modalService;

        private bool IsExecuting = false;

        private Dictionary<Modal, Type> ModalMapping = new Dictionary<Modal, Type>()
        {
            // TODO: rename PointsModal
            { Modal.AdjustablePointsScorer, typeof(PointsModal)},
            { Modal.PowerAction, typeof(PowerActionModal)}
        };

        public UiQueueExecutor(IUiQueueService uiQueueService, IModalService modalService) {
            this.uiQueueService = uiQueueService ?? throw new ArgumentNullException(nameof(uiQueueService));
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
        }

        public void Add(UiEvent uiEventToAdd) =>
            uiQueueService.Add(uiEventToAdd);

        public void ExecuteQueue()
        {
            if (IsExecuting)
            {
                modalService.Close(ModalResult.Ok(true));
                return;
            }

            var itemToProcess = uiQueueService.GetNextEvent();

            if (itemToProcess == null)
            {
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
            ExecuteQueue();
        }
    }
}

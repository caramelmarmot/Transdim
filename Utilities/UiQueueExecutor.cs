using Blazored.Modal.Services;
using System;
using Transdim.DomainModel;
using Transdim.Service;

namespace Transdim.Utilities
{
    public class UiQueueExecutor
    {
        private readonly IUiQueueService uiQueueService;
        private readonly IModalService modalService;

        private bool IsExecuting = false;

        public UiQueueExecutor(IUiQueueService uiQueueService, IModalService modalService) {
            this.uiQueueService = uiQueueService ?? throw new ArgumentNullException(nameof(uiQueueService));
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
        }

        public void Add(Type type) {
            uiQueueService.Add(new UiEvent { ModalToShow = type, Title = "foo" });
        }

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

            IsExecuting = true;
            modalService.OnClose += ProcessNextItemFromQueue;
            modalService.Show(itemToProcess.Title, itemToProcess.ModalToShow);
        }

        private void ProcessNextItemFromQueue(ModalResult modalResult)
        {
            IsExecuting = false;
            uiQueueService.CompleteCurrent();
            modalService.OnClose -= ProcessNextItemFromQueue;
            ExecuteQueue();
        }
    }
}

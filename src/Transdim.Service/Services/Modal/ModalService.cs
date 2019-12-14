using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Transdim.DomainModel;

namespace Transdim.Service.Services.Modal
{
    internal class ModalService : IModalService
    {
        public event Func<Task> StateHasChanged;

        public bool IsVisible { get; private set; } = false;

        public string Title { get; private set; }

        public ModalIdentifier CurrentModalIdentifier { get; private set; } = ModalIdentifier.None;

        public ModalParameters Parameters { get; private set; }

        private readonly SemaphoreSlim signal = new SemaphoreSlim(0, 1);

        private ModalResult modalResult;

        public async Task<ModalResult> Show(string title, ModalIdentifier identifier)
        {
            return await Show(title, identifier, new ModalParameters());
        }

        public async Task<ModalResult> Show(string title, ModalIdentifier identifier, ModalParameters parameters)
        {
            ReinitializeModal();
            Title = title;
            CurrentModalIdentifier = identifier;
            Parameters = parameters;
            modalResult = null;

            await SetVisibleAndNotifyApp();

            // Block execution on this thread until the signal is recieved from CloseModal
            await signal.WaitAsync();

            ReinitializeModal();
            await SetHiddenAndNotifyApp();
            return modalResult;
        }

        public void Close(ModalResult result)
        {
            modalResult = result;
            signal.Release();
        }

        private void ReinitializeModal()
        {
            Title = null;
            CurrentModalIdentifier = ModalIdentifier.None;
            Parameters = null;
        }

        private async Task SetVisibleAndNotifyApp()
        {
            IsVisible = true;
            await StateHasChanged.Invoke();
        }

        private async Task SetHiddenAndNotifyApp()
        {
            IsVisible = false;
            await StateHasChanged.Invoke();
        }
    }
}

using Microsoft.AspNetCore.Components;
using System;
using Transdim.Service.Internal.Services.Modal;

namespace Transdim.Service
{
        public interface IModalService
        {
            event Action<ModalResult> OnClose;

            event Action<string, RenderFragment, ModalParameters> OnShow;

            void Show(string title, Type contentType);

            void Show(string title, Type contentType, ModalParameters parameters);

            void Cancel();

            void Close(ModalResult modalResult);
        }
}

using System;
using Transdim.DomainModel;

namespace Transdim.Service.Services.Modal
{
        public interface IModalService
        {
            event Action<ModalResult> BeforeClose;

            event Action<ModalResult> OnClose;

            event Action<string, ModalIdentifier, ModalParameters> OnShow;

            void Show(string title, ModalIdentifier modalIdentifier);

            void Show(string title, ModalIdentifier modalIdentifier, ModalParameters parameters);

            void Close(ModalResult modalResult);
        }
}

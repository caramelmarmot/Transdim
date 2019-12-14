using System;
using System.Threading.Tasks;
using Transdim.DomainModel;

namespace Transdim.Service.Services.Modal
{
    public interface IModalService
    {
        event Func<Task> StateHasChanged;

        bool IsVisible { get; }

        string Title { get; }

        ModalIdentifier CurrentModalIdentifier { get; }

        ModalParameters Parameters { get; }

        Task<ModalResult> Show(string title, ModalIdentifier identifier);

        Task<ModalResult> Show(string title, ModalIdentifier identifier, ModalParameters parameters);

        void Close(ModalResult modalResult);
    }
}

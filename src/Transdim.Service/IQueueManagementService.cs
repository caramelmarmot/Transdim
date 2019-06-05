using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IQueueManagementService
    {
        void AddImmediate(IUiEvent uiEvent);

        void Add(IUiEvent uiEvent);

        void AddFinal(IUiEvent uiEvent);

        IUiEvent TakeNextEvent();

        IUiEvent PreviewNextEvent();
    }
}
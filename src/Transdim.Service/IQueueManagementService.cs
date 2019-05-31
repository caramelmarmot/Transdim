using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IQueueManagementService
    {
        void Add(IUiEvent uiEvent);
        IUiEvent GetNextEvent();
    }
}
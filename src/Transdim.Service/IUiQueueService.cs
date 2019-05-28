using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IUiQueueService
    {
        IUiEvent GetNextEvent();

        void Add(IUiEvent uiEvent);

        void RegisterEventTaken();
    }
}
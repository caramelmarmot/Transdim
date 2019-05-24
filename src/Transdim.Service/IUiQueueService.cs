using Transdim.DomainModel;

namespace Transdim.Service
{
    public interface IUiQueueService
    {
        UiEvent GetNextEvent();

        void Add(UiEvent uiEvent);

        void RegisterEventTaken();
    }
}
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;

namespace Transdim.Service.Internal.Services
{
    internal class UiQueueService : IUiQueueService
    {
        private readonly List<IUiEvent> eventQueue = new List<IUiEvent>();

        public UiQueueService() { }

        public IUiEvent GetNextEvent() => eventQueue.FirstOrDefault();

        public void Add(IUiEvent uiEvent) => eventQueue.Add(uiEvent);

        public void RegisterEventTaken() {
            if (eventQueue.Any())
            {
                eventQueue.RemoveAt(0);
            }
        }
    }
}

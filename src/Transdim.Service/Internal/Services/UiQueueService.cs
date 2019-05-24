using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;

namespace Transdim.Service.Internal.Services
{
    internal class UiQueueService : IUiQueueService
    {
        private List<UiEvent> eventQueue = new List<UiEvent>();

        public UiQueueService() { }

        public UiEvent GetNextEvent() => eventQueue.FirstOrDefault();

        public void Add(UiEvent uiEvent) => eventQueue.Add(uiEvent);

        public void CompleteCurrent() {
            if (eventQueue.Any())
            {
                eventQueue.RemoveAt(0);
            }
        }
    }
}

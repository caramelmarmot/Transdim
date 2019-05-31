using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;

namespace Transdim.Service.Internal.Services
{
    internal class QueueManagementService : IQueueManagementService
    {
        //private readonly List<IUiEvent> ImmediateEventQueue = new List<IUiEvent>();
        private readonly List<IUiEvent> EventualEventQueue = new List<IUiEvent>();
        //private readonly List<IUiEvent> FinalEventQueue = new List<IUiEvent>();

        public void Add(IUiEvent uiEvent) => EventualEventQueue.Add(uiEvent);

        //public void AddImmediate(IUiEvent uiEvent) => ImmediateEventQueue.Add(uiEvent);

        //public void AddFinal(IUiEvent uiEvent) => FinalEventQueue.Add(uiEvent);

        public IUiEvent GetNextEvent()
        {
            var itemToReturn = EventualEventQueue.FirstOrDefault();
            if (itemToReturn != null)
            {
                EventualEventQueue.RemoveAt(0);
            }

            return itemToReturn;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Transdim.DomainModel;

namespace Transdim.Service.Services
{
    internal class QueueManagementService : IQueueManagementService
    {
        private readonly List<IUiEvent> ImmediateEventQueue = new List<IUiEvent>();
        private readonly List<IUiEvent> EventualEventQueue = new List<IUiEvent>();
        private readonly List<IUiEvent> FinalEventQueue = new List<IUiEvent>();

        private readonly IQueueExecutionService queueExecutionService;

        public QueueManagementService(IQueueExecutionService queueExecutionService)
        {
            this.queueExecutionService = queueExecutionService ?? throw new ArgumentNullException(nameof(queueExecutionService));
        }
        public void Add(IUiEvent uiEvent) => EventualEventQueue.Add(uiEvent);

        public void AddImmediate(IUiEvent uiEvent) => ImmediateEventQueue.Add(uiEvent);

        public void AddFinal(IUiEvent uiEvent) => FinalEventQueue.Add(uiEvent);

        public void Execute() => queueExecutionService.Execute();

        public IUiEvent TakeNextEvent()
        {
            var immediateEvent = ImmediateEventQueue.FirstOrDefault();
            if (immediateEvent != null)
            {
                ImmediateEventQueue.RemoveAt(0);
                return immediateEvent;
            }

            var eventualEvent = EventualEventQueue.FirstOrDefault();
            if (eventualEvent != null)
            {
                EventualEventQueue.RemoveAt(0);
                return eventualEvent;
            }

            var finalEvent = FinalEventQueue.FirstOrDefault();
            if (finalEvent != null)
            {
                FinalEventQueue.RemoveAt(0);
                return finalEvent;
            }

            return null;
        }

        public IUiEvent PreviewNextEvent() =>
            ImmediateEventQueue.FirstOrDefault() ??
            EventualEventQueue.FirstOrDefault() ??
            FinalEventQueue.FirstOrDefault();
    }
}

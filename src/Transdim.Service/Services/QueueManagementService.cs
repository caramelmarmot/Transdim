﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transdim.DomainModel;
using Transdim.Service.Services.Modal;

namespace Transdim.Service.Services
{
    internal class QueueManagementService : IQueueManagementService
    {
        private readonly List<IUiEvent> ImmediateEventQueue = new List<IUiEvent>();
        private readonly List<IUiEvent> EventualEventQueue = new List<IUiEvent>();
        private readonly List<IUiEvent> FinalEventQueue = new List<IUiEvent>();

        private readonly IModalService modalService;
        private readonly IScoreAnimationService scoreAnimationService;

        private bool currentlyExecuting = false;

        public QueueManagementService(IModalService modalService, IScoreAnimationService scoreAnimationService)
        {
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
            this.scoreAnimationService = scoreAnimationService ?? throw new ArgumentNullException(nameof(scoreAnimationService));
        }

        public void Add(IUiEvent uiEvent) => EventualEventQueue.Add(uiEvent);

        public void AddImmediate(IUiEvent uiEvent) => ImmediateEventQueue.Add(uiEvent);

        public void AddFinal(IUiEvent uiEvent) => FinalEventQueue.Add(uiEvent);

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

        public async Task Execute()
        {
            if (currentlyExecuting)
            {
                return;
            }

            var itemToProcess = TakeNextEvent();

            if (itemToProcess == null)
            {
                return;
            }

            currentlyExecuting = true;

            if (itemToProcess is IUiModalEvent modalToProcess)
            {
                await modalService.Show(modalToProcess.Title, modalToProcess.ModalIdentifier, modalToProcess.ModalParameters);
            }
            else if (itemToProcess is IUiComponentScoringEvent componentScoringToProcess)
            {
                scoreAnimationService.FadeOutAfterDismissal = (PreviewNextEvent() is IUiComponentScoringEvent);
                await scoreAnimationService.Score(componentScoringToProcess.GameComponent, componentScoringToProcess.Points);
            }
            else if (itemToProcess is IGameEvent gameUpdateEvent)
            {
                gameUpdateEvent.EventToPerform.Invoke();
            }

            currentlyExecuting = false;
            await Execute();
        }
    }
}

﻿using System;
using Transdim.DomainModel;

namespace Transdim.Service.Internal.Services
{
    internal class QueueExecutionService : IQueueExecutionService
    {
        private readonly IQueueManagementService queueManagementService;
        private readonly IModalService modalService;
        private readonly IScoreAnimationService scoreAnimationService;

        private bool currentlyExecuting = false;

        public QueueExecutionService(IQueueManagementService queueManagementService, IModalService modalService, IScoreAnimationService scoreAnimationService)
        {
            this.queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
            this.modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
            this.scoreAnimationService = scoreAnimationService ?? throw new ArgumentNullException(nameof(scoreAnimationService));
        }

        public void Execute()
        {
            if (currentlyExecuting)
            {
                return;
            }

            var itemToProcess = queueManagementService.GetNextEvent();

            if (itemToProcess == null)
            {
                return;
            }

            currentlyExecuting = true;

            if (itemToProcess is IUiModalEvent modalToProcess)
            {
                modalService.OnClose += ProcessNext;

                modalService.Show(modalToProcess.Title, modalToProcess.ModalIdentifier);
            }
            else if (itemToProcess is IUiComponentScoringEvent componentScoringToProcess)
            {
                scoreAnimationService.OnFinishAnimation += ProcessNext;
                scoreAnimationService.Score(componentScoringToProcess.GameComponent, componentScoringToProcess.Points);
            }
        }

        private void ProcessNext(ModalResult modalResult)
        {
            modalService.OnClose -= ProcessNext;
            ProcessNext();
        }

        private void ProcessNext()
        {
            scoreAnimationService.OnFinishAnimation -= ProcessNext;
            currentlyExecuting = false;

            Execute();
        }
    }
}
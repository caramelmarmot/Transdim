using System;

namespace Transdim.Service.Internal.Services
{
    internal class QueueExecutionService
    {
        private readonly IQueueManagementService queueManagementService;

        public QueueExecutionService()
        {
            queueManagementService = queueManagementService ?? throw new ArgumentNullException(nameof(queueManagementService));
        }


    }
}

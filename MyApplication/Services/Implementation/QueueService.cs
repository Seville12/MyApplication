using BAL.Models;
using BAL.Services;
using Mapster;
using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Services.Implementation
{
    internal class QueueService : IQueueService
    {
        private readonly IQueueBalService queService;
        public QueueService(IQueueBalService queService)
        {
            this.queService = queService;
        }

        public async Task<int> CreateQue(Queue queue)
        {
            var queueV = queue.Adapt<BQueue>();
            await this.queService.CreateQue(queueV);
            return queueV.QueueId;
        }

        public async Task<IEnumerable<Microwave>> GetMicrowave()
        {
            return (await this.queService.GetMicrowave()).Adapt<IEnumerable<Microwave>>();
        }

        public async Task<IEnumerable<Queue>> GetQueue(string user)
        {
            return (await this.queService.GetQueue(user)).Adapt<IEnumerable<Queue>>();
        }

        public async Task<IEnumerable<UsingTime>> GetUsingTime()
        {
            return (await this.queService.GetUsingTime()).Adapt<IEnumerable<UsingTime>>();
        }
    }
}

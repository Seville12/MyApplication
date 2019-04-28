using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using DAL.Models;
using DAL.Services;
using Mapster;

namespace BAL.Services.Implementation
{
    public class QueueBalService : IQueueBalService
    {
        private readonly IQueueDalService queueService;
        public QueueBalService(IQueueDalService queueService)
        {
            this.queueService = queueService;
        }

        public async Task CreateQue(BQueue queue)
        {
            var queueD = queue.Adapt<DQueue>();
            await this.queueService.CreateQue(queueD);
        }

        public async Task<IList<BQueue>> GetQueue(string user)
        {
            var queueD = await this.queueService.GetQueue(user);
            return queueD.Select(el => (el.Adapt<BQueue>())).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using MyApplication.Data;

namespace DAL.Services.Implementation
{
    internal class QueueDalService : IQueueDalService
    {
        private readonly ApplicationDbContext db;
        public QueueDalService(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task CreateQue(DQueue queue)
        {
            //var microwaveId = db.DMicrowaves.Join;
            //var usingTimeId = db.DUsingTimes;
            this.db.DQueues.Add(queue);
            await this.db.SaveChangesAsync();
        }
        
        public async Task<IList<DQueue>> GetQueue(string user)
        {
            return await db.DQueues.Include(q => q.Microwave).Include(q => q.UsingTime).ToListAsync();
        }

    }
}

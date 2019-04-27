using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Services
{
    /// <summary>
    /// Интерефейс работы с очередью
    /// </summary>
    public interface IQueueService
    {
        /// <summary>
        /// Получает список очереди
        /// </summary>
        Task<IEnumerable<Queue>> GetQueue(string user);

        /// <summary>
        /// Создание записи очереди
        /// </summary>
        /// <param name="queue">Очередь</param>
        Task<int> CreateQue(Queue queue);
    }
}

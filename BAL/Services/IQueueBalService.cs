using BAL.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    /// <summary>
    /// Интерефейс работы с очередью
    /// </summary>
    public interface IQueueBalService
    {
        /// <summary>
        /// Получает список очереди
        /// </summary>
        Task<IList<BQueue>> GetQueue(string user);

        /// <summary>
        /// Создание записи очереди
        /// </summary>
        /// <param name="queue">Очередь</param>
        Task CreateQue(BQueue queue);
    }
}

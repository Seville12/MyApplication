using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    /// <summary>
    /// Интерефейс работы с очередью
    /// </summary>
    public interface IQueueDalService
    {
        /// <summary>
        /// Получает список очереди
        /// </summary>
        Task<IList<DQueue>> GetQueue(string user);

        /// <summary>
        /// Создание записи очереди
        /// </summary>
        /// <param name="queue">Очередь</param>
        Task CreateQue(DQueue queue);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    /// <summary>
    /// Комната отдыха
    /// </summary>
    public class DRelaxRoom
    {
        /// <summary>
        /// Индентификатор команты отдыха
        /// </summary>
        public int RelaxRoomId { get; set; }
        /// <summary>
        /// Название комнаты отдыха
        /// </summary>
        public string Name { get; set; }
    }
}

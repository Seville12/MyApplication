﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    /// <summary>
    /// Комната отдыха
    /// </summary>
    public class RelaxRoom
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    /// <summary>
    /// Время использования
    /// </summary>
    public class UsingTime
    {
        /// <summary>
        /// Индентификатор время использования
        /// </summary>
        public int UsingTimeId { get; set; }
        /// <summary>
        /// Время использования
        /// </summary>
        public float Value { get; set; }
    }
}

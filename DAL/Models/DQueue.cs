﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    /// <summary>
    /// Очередь
    /// </summary>
    public class DQueue
    {
        /// <summary>
        /// Индентификатор микроволновки
        /// </summary>
        public int QueueId { get; set; }
        /// <summary>
        /// Имя 
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Время начала работы микроволновки
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Время работы микроволновки
        /// </summary>
        public int UsingTimeId { get; set; }
        /// <summary>
        /// Индентификатор микроволновки
        /// </summary>
        public int MicrowaveId { get; set; }

        /// <summary>
        /// Свзяь с таблицей "Время работы"
        /// </summary>
        public virtual DUsingTime UsingTime { get; set; }
        /// <summary>
        /// Связь с таблицей "Микроволновка"
        /// </summary>
        public virtual DMicrowave Microwave { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    /// <summary>
    /// Очередь
    /// </summary>
    public class Queue
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
        public virtual UsingTime UsingTime { get; set; }
        /// <summary>
        /// Связь с таблицей "Микроволновка"
        /// </summary>
        public virtual Microwave Microwave { get; set; }
      
    }
}

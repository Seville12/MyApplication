using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    /// <summary>
    /// Время использования
    /// </summary>
    public class DUsingTime
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

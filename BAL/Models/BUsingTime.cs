using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Models
{
    /// <summary>
    /// Время использования
    /// </summary>
    public class BUsingTime
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

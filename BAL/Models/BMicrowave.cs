using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Models
{
    /// <summary>
    /// Микроволновка
    /// </summary>
    public class BMicrowave
    {
        /// <summary>
        /// Идентификатор микроволновки
        /// </summary>
        public int MicrowaveId { get; set; }
        /// <summary>
        /// Марка микроволновки
        /// </summary>
        public string Mark { get; set; }
        /// <summary>
        /// Идентификатор комнаты отдыха
        /// </summary>
        public int RelaxRoonId { get; set; }

        /// <summary>
        /// Связь с таблицей "Комната отдыха"
        /// </summary>
        public virtual BRelaxRoom RelaxRoom { get; set; }
    }
}

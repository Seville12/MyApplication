using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class Queue
    {
        public int QueueId { get; set; }
        public string User { get; set; }
        public DateTime StartDate { get; set; }
        public int UsingTimeId { get; set; }
        public int MicrowaveId { get; set; }

        public virtual UsingTime UsingTime { get; set; }
        public virtual Microwave Microwave { get; set; }
      
    }
}

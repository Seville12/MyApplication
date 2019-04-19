using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class Microwave
    {
        public int MicrowaveId { get; set; }
        public string Mark { get; set; }
        public int RelaxRoonId { get; set; }

        public virtual RelaxRoom RelaxRoom { get; set; }

    }
}

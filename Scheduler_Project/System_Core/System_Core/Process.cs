using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace System_Core
{
    public class Process
    {
        private int UUID;
        
        public Process(int UUID)
        {
            this.UUID = UUID;
        }

        public void execute()
        {
            Console.WriteLine("Executing Process " + UUID + "...");
        }
    }
}

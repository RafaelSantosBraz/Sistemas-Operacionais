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
        private int original_priority;
        private int current_priority;
        private int difference;

        public Process(int UUID)
        {
            this.UUID1 = UUID;
        }

        public int Original_priority { get => original_priority; set => original_priority = value; }
        public int Current_priority { get => current_priority; set => current_priority = value; }
        public int Difference { get => difference; set => difference = value; }
        public int UUID1 { get => UUID; set => UUID = value; }

        public void execute()
        {
            Console.WriteLine("Executing Process " + UUID1 + "...");
        }
    }
}

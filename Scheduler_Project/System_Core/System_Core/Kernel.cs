using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    public static class Kernel
    {
        
        public static void load_processes(List<Process> processes)
        {
            Scheduler.insertion_processes(processes);
        }        
    }
}

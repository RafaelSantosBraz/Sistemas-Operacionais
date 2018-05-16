using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace System_Core
{
    public static class Kernel
    {
        private static Timer clock;

        public static bool load_processes(List<Process> processes)
        {
            return Scheduler.insertion_processes(processes);
        }        

        public static void start_time_sharing()
        {
            clock = new Timer();
            clock.Interval = 10000;
            clock.Elapsed += Scheduler.schedule;
            clock.Enabled = true;
        }

        public static void close_time_sharing()
        {
            clock.Enabled = false;
        }
    }
}

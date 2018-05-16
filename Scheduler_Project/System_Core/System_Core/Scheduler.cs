using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    static class Scheduler
    {
        private static List<Process> ready = new List<Process>();
        private static int rule = 1;

        public static Process select()
        {
            switch (rule)
            {
                case 1:
                    return FIFO();
                default:
                    return null;
            }
        }

        public static void schedule(Object source, System.Timers.ElapsedEventArgs e)
        {
            
        } 

        public static bool insertion_processes(List<Process> processes)
        {
            switch (rule)
            {
                case 1:
                    {
                        ready = new List<Process>();
                        foreach (Process aux in processes)
                        {
                            ready.Add(aux);
                        }
                        return true;
                    }
            }
            return false;
        }

        private static bool change_rule(int new_rule)
        {
            if (new_rule > 0 && new_rule < 6)
            {
                return false;
            }
            else
            {
                rule = new_rule;
                return true;
            }
        }

        private static Process FIFO()
        {
            if (ready.Count == 0)
            {
                return null;
            }
            else
            {
                Process selected = ready.ElementAt(0);
                ready.RemoveAt(0);
                ready.Add(selected);
                return selected;
            }
        }
    }
}

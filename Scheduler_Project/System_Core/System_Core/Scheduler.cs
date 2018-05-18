﻿using System;
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
                case 2:
                    return Priority();
                default:
                    return null;
            }
        }

        public static void schedule(Object source, System.Timers.ElapsedEventArgs e)
        {
            Process running = select();
            running.execute();
        }

        public static bool insertion_processes(List<Process> processes)
        {
            switch (rule)
            {
                case 1:
                    {
                        ready = processes;
                        return true;
                    }
                case 2:
                    {
                        ready = processes;
                        ready.Sort((x, y) => x.Original_priority - y.Original_priority);
                        foreach (Process aux in ready)
                        {
                            aux.Current_priority = aux.Original_priority;
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
                Console.WriteLine("---> Selection reason: FIFO");
                return selected;
            }
        }

        private static Process Priority()
        {
            return new Process(1);
        }
    }
}

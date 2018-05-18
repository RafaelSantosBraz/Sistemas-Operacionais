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
        // cronômetro para controlar o Time Sharing
        private static Timer clock;

        // envio dos processos de alto nível para organização interna em baixo nível
        public static bool load_processes(List<Process> processes)
        {
            return Scheduler.insertion_processes(processes);
        }        

        // responsável por inicializar os atributos do Time Sharing
        public static void start_time_sharing()
        {
            clock = new Timer();
            clock.Interval = 2000;
            clock.Elapsed += Scheduler.schedule;
            clock.Enabled = true;            
        }

        // apenas faz o cancelamento do Time Sharing
        public static void close_time_sharing()
        {
            clock.Enabled = false;
        }

        // solicita a mudança de regra ao escalonador
        public static bool change_rule_scheduler(int new_rule)
        {
            return Scheduler.change_rule(new_rule);
        }
    }
}

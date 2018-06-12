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
        // instância de Semáforo para controlar a região crítica -- poderiam existir múltiplas regiões críticas
        private static Semaphore semaphore = new Semaphore();

        // envio dos processos de alto nível para organização interna em baixo nível
        public static void load_processes(List<Process> processes)
        {
            foreach (Process aux in processes)
            {
                semaphore.load_process(aux);
            }
        }        

        // responsável por inicializar os atributos do cronômetro
        public static void start_time_control()
        {
            clock = new Timer();
            clock.Interval = 5000;
            clock.Elapsed += get_next_process;
            clock.Enabled = true;            
        }

        // faz a chamada do semáforo e coloca o processo para execução na CPU
        private static void get_next_process(object sender, ElapsedEventArgs e)
        {
            Process aux = semaphore.next();
            if (aux != null)
            {
                aux.execute();
            }
            else
            {
                Console.WriteLine("Sem Processos para Execução!");
            }
        }

        // apenas faz o cancelamento do cronômetro
        public static void close_time_control()
        {
            clock.Enabled = false;
        }

        //// solicita a mudança de regra ao escalonador
        //public static bool change_rule_scheduler(int new_rule)
        //{
        //    return Scheduler.change_rule(new_rule);
        //}
    }
}

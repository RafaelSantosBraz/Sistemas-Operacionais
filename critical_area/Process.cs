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
        // identificador do processo
        private int UUID;    
        // cronômetro interno de execução do processo
        private static Timer clock;
        // indica o tempo de execução do processo
        private int execution_time; 

        public Process(int UUID, int execution_time)
        {
           UUID1 = UUID;
           this.
        }

        public int UUID1 { get => UUID; set => UUID = value; }

        // método de execução de cada processo
        public void execute()
        {
            Console.WriteLine("Executando o Processo " + UUID1 + "...\n");        
        }

        // responsável por inicializar os atributos do Time Sharing
        private static void executing()
        {
            clock = new Timer();
            clock.Interval = execution_time;
            clock.Elapsed += Scheduler.schedule;
            clock.Enabled = true;            
        }

        // apenas faz o cancelamento do Time Sharing
        public static void close_time_sharing()
        {
            clock.Enabled = false;
        }

        // processo mais amplo - chama a seleção e depois executa o processo selecionado
        public static void ending(Object source, System.Timers.ElapsedEventArgs e)
        {
            Process running = select();
            running.execute();
        }
    }
}

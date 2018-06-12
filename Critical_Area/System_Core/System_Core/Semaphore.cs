using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    // não é estática, pois é única para cada região crítica
    class Semaphore
    {
        // controla quantos processos estão na lista de execução e indica se algum está sendo processado
        public int control_variable { get; set; }
        // fila de processos em espera para a região crítica
        private Queue<Process> waiting; 

        public Semaphore()
        {
            control_variable = -1;
            waiting = new Queue<Process>();
        }     

        // carrega um processo na lista de espera
        public void load_process(Process process)
        {
            waiting.Enqueue(process);
            if (control_variable > 0)
            {
                control_variable++;
            }
            else
            {
                control_variable = 1;
            }
        }

        // determina qual é o próximo processo a assumir a CPU
        public Process next()
        {
            if (control_variable == -1)
            {
                return null;
            }
            if (control_variable == 0)
            {
                control_variable--;
                return null;
            }
            control_variable--;
            return waiting.Dequeue();
        }                   
    }
}
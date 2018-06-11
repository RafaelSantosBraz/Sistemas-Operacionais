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
        private int control_variable;
        // fila de processos em espera para a região crítica
        private Queue<Process> waiting; 
        public Semaphore()
        {
            control_variable = -1;
            waiting = new Queue<Process>();
        }

        // get e set

        // carrega um processo na lista de espera
        public void load_process(Process process)
        {
            waiting.Enqueue(process);
            control_variable++;
        }

       
    }
}
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
        // prioridade origninal - definida em alto nível
        private int original_priority;
        // prioridade atual - definida em baixo nível
        private int current_priority;
        // indica o usuário dono do processo
        private int owner;

        public Process(int UUID)
        {
           UUID1 = UUID;
        }

        public int Original_priority { get => original_priority; set => original_priority = value; }
        public int Current_priority { get => current_priority; set => current_priority = value; }       
        public int UUID1 { get => UUID; set => UUID = value; }
        public int Owner { get => owner; set => owner = value; }

        // método de execução de cada processo
        public void execute()
        {
            Console.WriteLine("Executando o Processo " + UUID1 + "...\n");
        }
    }
}

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

        public Process(int UUID)
        {
            UUID1 = UUID;
        }

        public int UUID1 { get => UUID; set => UUID = value; }

        // método de execução de cada processo
        public void execute()
        {
            Console.WriteLine("Executando o Processo " + UUID1 + "...\n");
        }      
    }
}

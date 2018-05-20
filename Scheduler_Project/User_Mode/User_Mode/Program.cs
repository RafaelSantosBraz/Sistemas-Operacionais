using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Core;

namespace User_Mode
{
    class Program
    {
        static void Main(string[] args)
        {
            // solicita (INADEQUADAMENTE! - apenas para teste!) a troca de regra ao núcleo e ao escalonador
            Kernel.change_rule_scheduler(3);
            Console.WriteLine("Iniciando escalonador e inserindo processos... (" + Kernel.load_processes(process_generator(1)) + ")\n");            
            Kernel.start_time_sharing();
            Console.ReadKey();
        }

        // gera a lista de processos em alto nível para uma regra de escalonamento
        public static List<Process> process_generator(int rule_type)
        {
            List<Process> processes = new List<Process>();
            switch (rule_type)
            {
                case 1:
                    {
                        processes.Add(new Process(0) { Original_priority = 1 });
                        processes.Add(new Process(1) { Original_priority = 2 });
                        processes.Add(new Process(2) { Original_priority = 3 });
                        processes.Add(new Process(3) { Original_priority = 1 });
                        processes.Add(new Process(4) { Original_priority = 3 });
                        break;
                    }
            }
            return processes;
        }
    }
}

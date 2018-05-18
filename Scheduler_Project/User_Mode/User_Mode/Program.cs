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
            List<Process> processes = new List<Process>();
            processes.Add(new Process(0) {Original_priority = 1 });
            processes.Add(new Process(1) { Original_priority = 2 });
            processes.Add(new Process(2) { Original_priority = 3 });
            processes.Add(new Process(3) { Original_priority = 1 });
            Console.WriteLine("Inserção de Processos: " + Kernel.load_processes(processes));
            Kernel.start_time_sharing();
            Console.ReadKey();
        }
    }
}

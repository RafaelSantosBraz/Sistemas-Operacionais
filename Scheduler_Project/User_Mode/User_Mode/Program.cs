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
            for (int i = 0; i < 10; i++)
            {
                processes.Add(new Process(i));
            }
            Console.WriteLine("Inserção de Processos: " + Kernel.load_processes(processes));
            Kernel.start_time_sharing();
            Console.ReadKey();
        }
    }
}

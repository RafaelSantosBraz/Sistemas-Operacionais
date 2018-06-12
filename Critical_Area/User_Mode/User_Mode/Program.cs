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
            Console.WriteLine("Inicializando Região Crítica");
            List<Process> aux = new List<Process>();
            for (int i = 0; i < 3; i++)
            {
                aux.Add(new Process(i));
            }            
            Kernel.load_processes(aux);
            Kernel.start_time_control();
            Console.ReadKey();
        }
    }
}

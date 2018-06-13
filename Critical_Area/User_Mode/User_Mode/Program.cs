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
            int op = Console.Read();
            if (op == '0')
            {
                Console.WriteLine("Inicializando Região Crítica -- Semáforo");
                List<Process> aux = new List<Process>();
                for (int i = 0; i < 3; i++)
                {
                    aux.Add(new Process(i));
                }
                Kernel.load_processes(aux);
                Kernel.start_time_control();
            }
            else
            {
                Console.WriteLine("Inicializando Região Crítica -- Produtor-Consumidor");                
                Kernel.load_producer_consumer(new Producer(0), new Consumer(1));
                Kernel.start_time_control();
            }
            Console.ReadKey();
        }
    }
}

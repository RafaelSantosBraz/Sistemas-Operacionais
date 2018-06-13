using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    public class Consumer : Process
    {
        public Consumer(int UUID) : base(UUID)
        {
        }

        // procedimento de consumo dos dados
        public void execute(List<int> input)
        {
            execute();
            String aux = "";
            foreach (int number in input)
            {
                aux += number + " ";
            }
            Console.WriteLine("Consumidos: " + aux + "\n");
        }
    }
}

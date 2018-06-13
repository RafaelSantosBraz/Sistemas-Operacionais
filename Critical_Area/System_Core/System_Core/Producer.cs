using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    public class Producer : Process
    {
        public Producer(int UUID) : base(UUID)
        {
        }

        // realiza a produção a qual o processo é responsável
        public new List<int> execute()
        {
            base.execute();
            List<int> aux = new List<int>();
            Random random = new Random();
            for (int c = 0; c < 5; c++)
            {
                aux.Add(random.Next(0, 99));
            }
            String content = "";
            foreach (int number in aux)
            {
                content += number + " ";
            }
            Console.WriteLine("Produzidos: " + content + "\n");
            return aux;
        }
    }
}

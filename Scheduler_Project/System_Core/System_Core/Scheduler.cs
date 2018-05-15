using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    static class Scheduler
    {
        private static List<Container> ready = new List<Container>();
        private static int rule = 1;
        static Object a;

        public static Container select()
        {
            switch (rule)
            {
                case 1:
                    return FIFO();
                default:
                    return null;
            }
        }

        private static bool change_rule(int new_rule)
        {
            if (new_rule > 0 && new_rule < 6)
            {
                return false;
            }
            else
            {
                rule = new_rule;
                return true;
            }
        }

        private static Container FIFO()
        {
            if (ready.Count == 0)
            {
                return null;
            }
            else
            {
                Container selected = ready.ElementAt(0);
                ready.RemoveAt(0);
                ready.Add(selected);
                return selected;
            }
        }
    }
}

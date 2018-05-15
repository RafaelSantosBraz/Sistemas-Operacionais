using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    class Container
    {
        private Process process;

        public Container()
        {
            
        }

        public Process Process { get => process; set => process = value; }
    }
}

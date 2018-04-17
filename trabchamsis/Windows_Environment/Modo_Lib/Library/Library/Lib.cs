using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Core;

namespace Library
{
    public static class Lib
    {
        // método de leitura da biblioteca (sem acesso ao arquivo)
        public static String Read(int begin, int end)
        {
            return Core.External_Read(begin, end);
        }

        // método de escrita da biblioteca (sem acesso ao arquivo)
        public static bool Write(String value)
        {
            return Core.External_Write(value);
        }
    }
}

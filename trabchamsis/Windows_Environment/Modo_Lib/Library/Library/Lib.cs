using System;
using System_Core;

namespace Library
{
    public class Lib
    {
        // referência ao núcleo do sistema
        private Core reference;

        public Lib()
        {
            reference = new Core();
        }

        // método de leitura da biblioteca (sem acesso ao arquivo)
        public String Read(int begin, int end)
        {
            return reference.Read(begin, end);
        }

        // método de escrita da biblioteca (sem acesso ao arquivo)
        public bool Write(String value)
        {
            return reference.Write(value);
        }
    }
}

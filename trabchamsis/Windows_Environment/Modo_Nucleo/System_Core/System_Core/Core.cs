using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System_Core
{
    public static class Core
    {
        // caminho dos dados, acesso restrito ao núcleo
        private static String data_path = @"data.txt";

        // rotina de leitura aberta
        public static String External_Read(int x, int y)
        {
            return Read(x, y);
        }

        // rotina de escrita aberta
        public static bool External_Write(String value)
        {
            return Write(value);
        }

        // realiza a leitura da posição X à Y (interno ao Núcleo)
        private static String Read(int x, int y)
        {
            try
            {
                FileStream data = File.Open(data_path, FileMode.OpenOrCreate);
                // marca ponteiro em posição específica
                data.Position = x;
                StreamReader reader = new StreamReader(data);
                String text = "";
                // leitura sequência da posição x à y
                for (int c = x; c <= y; c++)
                {
                    if (!reader.EndOfStream)
                    {
                        text += (Char)reader.Read();
                    }
                    else
                    {
                        // se for final do arquivo, foi solicitada uma posição maior do que o tamanho do arquivo
                        return null;
                    }
                }
                return text;
            }
            catch
            {
                // erros diversos (interrupção, múltiplos acessos, etc.) retornam null
                return null;
            }
        }

        // realiza a escrita de um valor (String) no final do arquivo (interno ao Núcleo)
        private static bool Write(String value)
        {
            try
            {
                FileStream data = File.Open(data_path, FileMode.OpenOrCreate);
                StreamWriter writer = new StreamWriter(data);
                StreamReader reader = new StreamReader(data);
                if (data.Length == 0)
                {
                    data.Position = 0;
                }
                else
                {
                    data.Position = data.Length - 1;
                }
                //reader.ReadToEnd();
                writer.Write(value);
                // gravação física das alterações no objeto
                writer.Dispose();
                return true;
            }
            catch
            {
                // erros diversos (interrupção, múltiplos acessos, etc.) retornam null
                return false;
            }
        }
    }
}

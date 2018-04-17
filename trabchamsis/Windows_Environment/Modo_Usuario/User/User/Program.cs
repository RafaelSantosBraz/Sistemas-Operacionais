using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool aux = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Opção de Leitura: 0");
                Console.WriteLine("Opção de Escrita: 1");
                Console.WriteLine("Opção de Saída: !0 && !1");
                Console.Write("Opção: ");
                char op = Console.ReadLine()[0];
                switch (op)
                {
                    case '0':
                        {
                            Console.Write("Posição de Início da Leitura: ");
                            int begin = int.Parse(Console.ReadLine());
                            Console.Write("Posição de fim da Leitura: ");
                            int end = int.Parse(Console.ReadLine());
                            String result = Lib.Read(begin, end);
                            if (result == null)
                            {
                                Console.WriteLine("Não é possível realizar a Leitura!");
                            }
                            else
                            {
                                Console.WriteLine("Valor de Resposta: " + result);
                            }
                            break;
                        }
                    case '1':
                        {
                            Console.Write("Valor para Escrita: ");
                            String value = Console.ReadLine();
                            if (!Lib.Write(value))
                            {
                                Console.WriteLine("Não é possível realizar a Escrita!");
                            }
                            else
                            {
                                Console.WriteLine("Escrita realizada!");
                            }
                            break;
                        }
                    default:
                        aux = false;
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar!");
                Console.ReadKey();
            } while (aux);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    static class Scheduler
    {
        // lista dos processos em estado "pronto"
        private static List<Process> ready = new List<Process>();
        // define qual regra será utilizada pelo escalonador para escolha do processo
        private static int rule = 1;

        // método para direcionar a tarefa de escolha do processo para uma rotina específica (regra) 
        public static Process select()
        {
            switch (rule)
            {
                case 1:
                    return FIFO();
                case 2:
                    return Priority();
                default:
                    return null;
            }
        }

        // processo mais amplo - chama a seleção e depois executa o processo selecionado
        public static void schedule(Object source, System.Timers.ElapsedEventArgs e)
        {
            Process running = select();
            running.execute();
        }

        // faz a organização/formatação dos processos de alto nível no contexto do núcleo do SO de acordo com a regra especificada
        public static bool insertion_processes(List<Process> processes)
        {
            switch (rule)
            {
                case 1:
                    {
                        // caso FIFO - não é preciso alterar os processos
                        ready = processes;
                        return true;
                    }
                case 2:
                    {
                        // caso Prioridade - necessário tratar a prioridade corrente
                        ready = processes;
                        // ordena os processos pela prioridade original
                        ready.Sort((x, y) => x.Original_priority - y.Original_priority);
                        // copia a prioridade original para a corrente
                        foreach (Process aux in ready)
                        {
                            aux.Current_priority = aux.Original_priority;
                        }
                        return true;
                    }
            }
            return false;
        }

        // método para alterar a regra atual do escalonador
        public static bool change_rule(int new_rule)
        {
            if (new_rule > 0 && new_rule < 6)
            {
                rule = new_rule;
                return true;
            }
            else
            {
                return false;
            }
        }

        // rotina para escalonar por FIFO de lista circular
        private static Process FIFO()
        {
            if (ready.Count == 0)
            {
                return null;
            }
            // sempre o primeiro elemento da lista
            else
            {
                Process selected = ready.ElementAt(0);
                ready.RemoveAt(0);
                ready.Add(selected);
                Console.WriteLine("---> Motivo de Seleção: FIFO - primeiro elemento da lista");
                return selected;
            }
        }

        // rotina para escalonar por Prioridade
        private static Process Priority()
        {
            if (ready.Count == 0)
            {
                return null;
            }
            else
            {
                // cria uma nova lista com os processos de mesma e maior prioridade atual
                List<Process> bigger = ready.FindAll(process => process.Current_priority == ready.Max(process_aux => process_aux.Current_priority));
                // ordena a nova lista por prioridade original
                bigger.Sort((x, y) => x.Original_priority - y.Original_priority);
                // o último elemento será o de maior prioridade, e será selecionado
                Process selected = bigger.Last();
                if (selected.Current_priority == 0)
                {
                    // não há processos escalonáveis, assim deve-se rearranjar a lista antes de escalonar
                    insertion_processes(ready);
                    return select();
                }
                // apenas definições de motivo de seleção
                if (bigger.Count == 1)
                {
                    Console.WriteLine("---> Motivo de Seleção: prioridade - maior prioridade atual");
                    selected.Current_priority--;
                    return selected;
                }
                Console.WriteLine("---> Motivo de Seleção: prioridade - empate - último elemento de mesma prioridade");
                selected.Current_priority--;
                return selected;
            }
        }       
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    static class Scheduler
    {
        // lista dos processos em estado "pronto"
        private static List<Process> ready;
        // define qual regra será utilizada pelo escalonador para escolha do processo
        private static int rule = 1;
        // armazena os bilhetes dos processos para escalar por loteria
        private static List<int> tickets;
        // agente para sorteio de bilhetes
        private static Random agent = new Random();
        // indica quem é o dono do processo executado por último
        private static User current_user;
        // indica quais são os usuários donos de processos
        private static List<User> users;
        // indica quem é a fila de prioridade executada por último
        private static Queue current_queue;
        // indica quais são as filas de prioridade existentes
        private static List<Queue> queues;

        // método para direcionar a tarefa de escolha do processo para uma rotina específica (regra) 
        public static Process select()
        {
            switch (rule)
            {
                case 1:
                    return FIFO();
                case 2:
                    return Priority();
                case 3:
                    return Lottery();
                case 4:
                    return Portion_fair();
                case 5:
                    return Priority_queue();
            }
            return null;
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
                case 3:
                    {
                        // caso Loteria
                        ready = processes;
                        tickets = new List<int>();
                        foreach (Process aux in ready)
                        {
                            // define que cada processo receberá a mesma quantidade de bilhetes que sua prioridade
                            for (int i = 1; i <= aux.Original_priority; i++)
                            {
                                tickets.Add(ready.IndexOf(aux));
                            }
                        }
                        return true;
                    }
                case 4:
                    {
                        // caso Fração Justa
                        ready = processes;
                        // ordena os processos pela prioridade original
                        ready.Sort((x, y) => x.Original_priority - y.Original_priority);
                        // armazena temporariamente os usuários
                        List<int> ids = new List<int>();
                        // armazena temporariamente a quantidade de processos para cada usuário
                        List<int> quantify_processs = new List<int>();
                        foreach (Process aux in ready)
                        {
                            aux.Current_priority = aux.Original_priority;
                            // atualiza o valor id e quantidade
                            if (ids.Exists(id => id == aux.Owner))
                            {
                                quantify_processs[ids.IndexOf(aux.Owner)] += 1;
                            }
                            else
                            {
                                ids.Add(aux.Owner);
                                quantify_processs.Add(1);
                            }
                        }
                        users = new List<User>();
                        foreach (int id in ids)
                        {
                            // corversão para o tipo usuário
                            users.Add(new User(id, quantify_processs.ElementAt(ids.IndexOf(id))));
                        }
                        // ordena os usuários por seu ID
                        users.Sort((x, y) => x.Id - y.Id);
                        // primeiro ID é o executado
                        current_user = users.ElementAt(0);
                        return true;
                    }
                case 5:
                    {
                        // caso Fila de Prioridade
                        ready = processes;
                        // ordena os processos pela prioridade original
                        ready.Sort((x, y) => x.Original_priority - y.Original_priority);
                        // armazena temporariamente as prioridades das filas
                        List<int> queues_priorities = new List<int>();
                        foreach (Process aux in ready)
                        {
                            // atualiza a prioridade da lista, caso não exista
                            if (!queues_priorities.Exists(queue => queue == aux.Original_priority))
                            {
                                queues_priorities.Add(aux.Original_priority);
                            }
                        }
                        queues = new List<Queue>();
                        foreach (int id in queues_priorities)
                        {
                            // conversão para tipo fila
                            queues.Add(new Queue(id, queues_priorities.Count));
                        }
                        // ordena as filas por suas respectivas prioridades
                        queues.Sort((x, y) => x.Priority_of_list - y.Priority_of_list);
                        // fila de maior prioridade é executada
                        current_queue = queues.Last();
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
            return false;
        }

        // rotina para escalonar por FIFO de lista circular
        private static Process FIFO()
        {
            if (ready.Count == 0)
            {
                return null;
            }
            // sempre o primeiro elemento da lista            
            Process selected = ready.ElementAt(0);
            ready.RemoveAt(0);
            ready.Add(selected);
            Console.WriteLine("---> Motivo de Seleção: FIFO - primeiro elemento da lista");
            return selected;
        }

        // rotina para escalonar por Prioridade
        private static Process Priority()
        {
            if (ready.Count == 0)
            {
                return null;
            }
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

        // rotina para escalar por loteria - sorteia um bilhete e retorna o processo correspondente
        private static Process Lottery()
        {
            if (tickets.Count == 0)
            {
                return null;
            }
            Console.WriteLine("---> Motivo de Seleção: loteria");
            return ready.ElementAt(tickets.ElementAt(agent.Next(tickets.Count())));
        }

        // rotina para escalonar por fração justa
        private static Process Portion_fair()
        {
            if (users.Count == 0)
            {
                return null;
            }
            // usuário já atingiu sua porção máxima 
            if (current_user.Current_portion == current_user.Max_portion)
            {
                // se não existir outro usuário seguinte, retorna ao primeiro
                if (users.Last() == current_user)
                {
                    current_user.Current_portion = 0;
                    current_user = users.First();
                }
                // se existir, apenas troca
                else
                {
                    current_user.Current_portion = 0;
                    current_user = users.ElementAt(users.IndexOf(current_user) + 1);
                }
            }
            // Deve fazer a seleção por prioridade para o usuário atual

            // cria uma nova lista com os processos do mesmo usuário
            List<Process> user_processes = ready.FindAll(process => process.Owner == current_user.Id);
            // cria uma nova lista com os processos de mesma e maior prioridade atual para o usuário
            List<Process> bigger = user_processes.FindAll(process => process.Current_priority == user_processes.Max(process_aux => process_aux.Current_priority));
            // ordena a nova lista por prioridade original
            bigger.Sort((x, y) => x.Original_priority - y.Original_priority);
            // o último elemento será o de maior prioridade, e será selecionado
            Process selected = bigger.Last();
            if (selected.Current_priority == 0)
            {
                // não há processos escalonáveis, assim deve-se rearranjar a lista do usuário atual antes de escalonar
                foreach (Process aux in user_processes)
                {
                    aux.Current_priority = aux.Original_priority;
                }
                return select();
            }
            // apenas definições de motivo de seleção
            if (bigger.Count == 1)
            {
                Console.WriteLine("---> Motivo de Seleção: porção justa - usuário " + selected.Owner + " - maior prioridade atual");
                selected.Current_priority--;
                current_user.Current_portion++;
                return selected;
            }
            Console.WriteLine("---> Motivo de Seleção: porção justa - usuário " + selected.Owner + " - empate - último elemento de mesma prioridade");
            selected.Current_priority--;
            current_user.Current_portion++;
            return selected;
        }

        // rotina para escalonar por Fila de Prioridade
        private static Process Priority_queue()
        {
            if (queues.Count == 0)
            {
                return null;
            }
            // fila já atingiu sua cota máxima de ciclos 
            if (current_queue.Current_cycle == current_queue.Maximum_cycles)
            {
                // se não existir outra fila seguinte, retorna à última
                if (queues.First() == current_queue)
                {
                    current_queue.Current_cycle = 0;
                    current_queue.Current_process = null;
                    current_queue = queues.Last();
                }
                // se existir, apenas troca
                else
                {
                    current_queue.Current_cycle = 0;
                    current_queue = queues.ElementAt(queues.IndexOf(current_queue) - 1);
                }
            }
            // cria uma nova lista com os processos da mesma lista corrente
            List<Process> queue_processes = ready.FindAll(process => process.Original_priority == current_queue.Priority_of_list);
            // se não existir outra processo seguinte, retorna ao primeiro
            if (queue_processes.Last() == current_queue.Current_process)
            {                
                current_queue.Current_process = queue_processes.First();
            }
            // se existir, apenas troca
            else
            {
                current_queue.Current_process = queue_processes.ElementAt(queue_processes.IndexOf(current_queue.Current_process) + 1);
            }                        
            Console.WriteLine("---> Motivo de Seleção: fila de prioridade - processo na posição atual da fila");
            current_queue.Current_cycle++;
            return current_queue.Current_process;
        }
    }
}

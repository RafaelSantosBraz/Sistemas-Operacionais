﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    class Queue
    {
        // quantidade máxima de processos a serem executados em sequência na lista
        private int maximum_cycles;
        // quantidade de processos executados até o momento
        private int current_cycle;
        // processo excutado por último na lista
        private Process current_process;
        // indica a prioridade da lista
        private int priority_of_list;

        public Queue(int priority_of_list, int quantity_list)
        {
            Priority_of_list = priority_of_list;
            // quanto maior for a prioridade da lista, menor será a quantidade de processos em sequência
            Maximum_cycles = quantity_list - Priority_of_list + 1;
            Current_cycle = 0;
            Current_process = null;
        }

        public int Maximum_cycles { get => maximum_cycles; set => maximum_cycles = value; }
        public int Current_cycle { get => current_cycle; set => current_cycle = value; }
        public Process Current_process { get => current_process; set => current_process = value; }
        public int Priority_of_list { get => priority_of_list; set => priority_of_list = value; }
    }
}

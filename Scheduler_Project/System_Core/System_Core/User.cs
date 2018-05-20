using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    class User
    {
        // quantidade de processos que o usuário pode executar em sequência
        private int max_portion;
        // quantidade de processos executados até o momento
        private int current_portion;
        // identificador do usuário
        private int id;

        public User(int id, int quantify_max_process)
        {
            Id = id;
            // Regra de Justiça: sempre metade dos processos por usuário
            Max_portion = (int)Math.Ceiling(quantify_max_process / 2.0);
        }

        public int Max_portion { get => max_portion; set => max_portion = value; }
        public int Current_portion { get => current_portion; set => current_portion = value; }
        public int Id { get => id; set => id = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philosopher__Dinner
{
    public class Fork
    {
        // indica o garfo
        private int ID;
        // variável do semáforo binário que controla o acesso ao garfo
        private bool control_variable;
        // indica qual é o filósofo que é o dono atual do garfo -- que pode utilizá-lo
        private Philosopher current_owner;
        // lista de espera para utilizar o garfo
        private Queue<Philosopher> philosophers_waiting;

        public Fork(int ID)
        {
            this.ID = ID;
            control_variable = false;
            current_owner = null;
            philosophers_waiting = new Queue<Philosopher>();            
        }

        // indica que um filósofo deseja uilizar o garfo
        public void insert_philosopher(Philosopher philosopher)
        {
            philosophers_waiting.Enqueue(philosopher);
            control_variable = true;
            check_queue();
        }

        // verifica o estado do garfo para mudar o dono do garfo
        private void check_queue()
        {
            if (current_owner == null && control_variable)
            {
                current_owner = philosophers_waiting.Dequeue();
                if (philosophers_waiting.Count == 0)
                {
                    control_variable = false;
                }
                notify_philosopher();
            }
        }

        // avisa o filósofo que o garfo está disponível para uso
        private void notify_philosopher()
        {
            current_owner.check_dependences();
        }

        // retorna quem é o dono atual do garfo 
        public Philosopher get_current_owner()
        {
            return current_owner;
        }

        // o filósofo notifica a liberação do garfo -- apena o filósofo dono pode liberar o recurso
        public void free_fork(Philosopher sender)
        {
            if (sender == current_owner)
            {
                current_owner = null;
                check_queue();                
            }            
        }
    }
}

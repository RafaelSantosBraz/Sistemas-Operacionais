using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Philosopher__Dinner
{
    public class Philosopher
    {
        // identificador do filósofo
        private int ID;
        // indica qual é o primeiro garfo que o filósofo precisa para comer
        private Fork first_fork;
        // indica qual é o segundo garfo que o filósofo precisa para comer
        private Fork second_fork;

        public Philosopher(int iD, Fork first_fork, Fork second_fork)
        {
            ID = iD;
            this.first_fork = first_fork;
            this.second_fork = second_fork;
            start_thinking();
        }

        // método para receber mensagem do garfo para verificar a dependência
        public void check_dependences()
        {
            // verificar se já possui os dois garfos
            if (first_fork.get_current_owner() == this && second_fork.get_current_owner() == this)
            {
                start_eating();
            }
        }

        // método para o filósofo começar a comer
        private void start_eating()
        {
            Console.WriteLine("Filósofo " + ID + " está comendo agora!");
            Timer clock = new Timer(new TimerCallback(end_eating));
            clock.Change(5000, 0);
        }

        // faz o filósofo parar de comer
        private void end_eating(object state)
        {
            Timer clock = (Timer)state;
            clock.Dispose();
            Console.WriteLine("-----------------------------------> Filósofo " + ID + " parou de comer!");
            // liberar os garfos
            first_fork.free_fork(this);
            second_fork.free_fork(this);
            // começa a pensar para depois se inserir na fila novamente
            start_thinking();
        }

        // filósofo está pensando antes de precisar comer novamente
        private void start_thinking()
        {
            Timer clock = new Timer(new TimerCallback(end_thinking));
            clock.Change(2000, 0);
        }

        // filósofo já quer comer novamente -- se insere na lista para os garfos que precisa
        private void end_thinking(object state)
        {
            Timer clock = (Timer)state;
            clock.Dispose();
            first_fork.insert_philosopher(this);
            second_fork.insert_philosopher(this);
        }
    }
}

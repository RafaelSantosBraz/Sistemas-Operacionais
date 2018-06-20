using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
        // cronômetro para o filósofo comer
        private Timer clock;

        public Philosopher(int iD, Fork first_fork, Fork second_fork)
        {
            ID = iD;
            this.first_fork = first_fork;
            this.second_fork = second_fork;
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
            eating();
        }

        // inicia o perído em que o filósofo está comendo
        private void eating()
        {
            clock = new Timer();
            clock.Interval = 5000;
            clock.Elapsed += end_eating;
            clock.Enabled = true;
        }

        // faz o filósofo parar de comer
        private void end_eating(object sender, ElapsedEventArgs e)
        {
            clock.Enabled = false;
            Console.WriteLine("Filósofo " + ID + " parou de comer!");
            // liberar os garfos
            first_fork.free_fork(this);
            second_fork.free_fork(this);
            // começa a pensar para depois se inserir na fila novamente
            start_thinking();
        }

        // filósofo está pensando antes de precisar comer novamente
        private void start_thinking()
        {
            clock = new Timer();
            clock.Interval = 2000;
            clock.Elapsed += end_thinking;
            clock.Enabled = true;
        }

        // filósofo já quer comer novamente -- se insere na lista para os garfos que precisa
        private void end_thinking(object sender, ElapsedEventArgs e)
        {
            first_fork.insert_philosopher(this);
            second_fork.insert_philosopher(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philosopher__Dinner
{
    class Table
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Preparando a mesa...");
            List<Philosopher> philosophers = new List<Philosopher>();
            List<Fork> forks = new List<Fork>();
            for (int c = 1; c < 6; c++)
            {
                forks.Add(new Fork(c));
            }
            philosophers.Add(new Philosopher(1, forks[0], forks[4]));
            philosophers.Add(new Philosopher(2, forks[1], forks[0]));
            philosophers.Add(new Philosopher(3, forks[2], forks[1]));
            philosophers.Add(new Philosopher(4, forks[3], forks[2]));
            philosophers.Add(new Philosopher(5, forks[4], forks[3]));
            Console.ReadKey();
        }
    }
}

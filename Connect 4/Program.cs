using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Connect4 grid = new Connect4();
            Random rnd = new Random();
            foreach (int i in Enumerable.Range(0, 30))
            {
                Console.WriteLine(grid.play(rnd.Next(0, 6)));
            }
            Console.ReadLine();
        }
    }
}

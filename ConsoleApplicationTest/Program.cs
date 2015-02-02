using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new TicTacToe.Bots.BotFactory();

            foreach (var bn in f.BotTypeNames)
                Console.WriteLine(bn);

            Console.WriteLine(f.CreatBot(f.BotTypeNames.First(), null, null));

            Console.Read();
        }
    }
}

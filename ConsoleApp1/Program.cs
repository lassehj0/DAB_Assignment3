using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("What do u want");
                Console.WriteLine("1. a");
                Console.WriteLine("2. b");
                string a = Console.ReadLine();
                if (a == "1")
                    Console.WriteLine("u chose a");
                if (a == "2")
                    Console.WriteLine("u chose b");
            }
        }
    }
}

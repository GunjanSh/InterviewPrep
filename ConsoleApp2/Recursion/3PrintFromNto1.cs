using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class PrintFromNto1
    {
        public static void Print()
        {
            Console.WriteLine("Enter number to print from N to 1");
            string input = Console.ReadLine();

            int.TryParse(input, out var n);

            Console.WriteLine("Without Recursion");

            for (int idx = n; idx >= 1; idx--)
            {
                Console.WriteLine("Name {0}", idx);
            }

            Console.WriteLine("With Recursion");

            Print(n, 1);
        }

        static void Print(int index, int N)
        {
            if (index < N)
            {
                return;
            }

            Console.WriteLine("Name {0}", index);

            Print(index - 1, N);
        }
    }
}

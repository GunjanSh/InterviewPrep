using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class PrintLinearlyFrom1toN
    {
        public static void Print()
        {
            Console.WriteLine("Enter number to print from 1 to N");
            string input = Console.ReadLine();

            int.TryParse(input, out var n);

            Console.WriteLine("Without Recursion");
            for (int idx = 1; idx <= n; idx++)
            {
                Console.WriteLine("{0}", idx);
            }

            Console.WriteLine("With Recursion");

            Print(1, n);
        }

        static void Print(int index, int N)
        {
            if (index > N)
            {
                return;
            }

            Console.WriteLine("{0}", index);

            Print(index + 1, N);
        }
    }
}

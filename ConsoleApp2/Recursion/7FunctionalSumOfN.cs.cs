using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class FunctionalSumOfN
    {
        public static void Sum()
        {
            Console.WriteLine("Enter number to sum from 1 to N");
            string input = Console.ReadLine();

            int.TryParse(input, out var n);

            Console.WriteLine("With functional");

            Console.WriteLine("Sum of 1 to {0} is {1}", n, Sum(n));
        }

        static int Sum(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return n + Sum(n - 1);
        }
    }
}

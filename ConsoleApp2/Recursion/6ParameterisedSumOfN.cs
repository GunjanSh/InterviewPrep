using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class ParameterisedSumOfN
    {
        public static void Sum()
        {
            Console.WriteLine("Enter number to sum from 1 to N");
            string input = Console.ReadLine();

            int.TryParse(input, out var n);

            Console.WriteLine("With parameterised");

            Sum(1, n, 0);
        }

        static void Sum(int index, int n, int sum)
        {
            if (index > n)
            {
                Console.WriteLine("Sum from 1 to {0} is {1}", n, sum);
                return;
            }

            Sum(index + 1, n, sum + index);
        }
    }
}

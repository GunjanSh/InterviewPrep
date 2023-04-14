using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    // Fibonacci series --> 0 1 1 2 3 5 8 13 21 34 55 etc ... sum of last two numbers.
    internal class Fibonacci
    {
        public static void FindFibonacci()
        {
            Console.WriteLine("Enter number to find the fibonacci of - ex N");
            int.TryParse(Console.ReadLine(), out var n);

            Console.WriteLine("Fibonacci of {0} is {1}", n, Fib(n));
        }

        static int Fib(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}

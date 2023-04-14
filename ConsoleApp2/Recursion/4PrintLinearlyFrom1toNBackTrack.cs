using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    // In back track do not use fn(i+1,n), instead achieve the same using i-1
    internal class _4PrintLinearlyFrom1toNBackTrack
    {
        public static void Print()
        {
            Console.WriteLine("Enter number to print from 1 to N");
            string input = Console.ReadLine();

            int.TryParse(input, out var n);

            Console.WriteLine("With Recursion using BackTrack");

            Print(n, n);
        }

        static void Print(int index, int n)
        {
            if (index < 1)
            {
                return;
            }

            Print(index - 1, n);

            Console.WriteLine(index);
        }
    }
}

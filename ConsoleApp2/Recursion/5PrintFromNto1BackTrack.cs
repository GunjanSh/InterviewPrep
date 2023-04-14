using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class _5PrintFromNto1BackTrack
    {
        public static void Print()
        {
            Console.WriteLine("Enter number to print from N to 1");
            string input = Console.ReadLine();

            int.TryParse(input, out var n);

            Console.WriteLine("With Recursion using BackTrack");

            Print(1, n);
        }

        static void Print(int index, int n)
        {
            if (index > n)
            {
                return;
            }

            Print(index + 1, n);

            Console.WriteLine(index);
        }
    }
}

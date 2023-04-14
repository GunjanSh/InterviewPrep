using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class SumOfDigits
    {
        public static int Sum(int number)
        {
            var noOfDigits = getDigitsCount(number);

            var divisor = (int)Math.Pow(10, noOfDigits - 1);

            var ans = 0;

            while (divisor != 0)
            {
                ans += (number / divisor); // Get quotient

                number %= divisor; // Since prev number is added, get remainder of the number
                divisor /= 10; // Reduce divisor
            }

            return ans;
        }

        public static int getDigitsCount(int number)
        {
            var count = 0;
            while (number != 0)
            {
                number /= 10; // Keeps eleiminating one digit
                count++;
            }

            return count;
        }
    }
}

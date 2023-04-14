using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class IsMagicNumber1
    {
        public static bool isMagicNumber(int number)
        {
            var sum = 0;

            while (number > 0 || sum > 9)   // When both are true, come out of loop
            {
                if (number == 0)   // when current number is added and becomes 0, set number to current sum to start summing digits again.
                {
                    number = sum;
                    sum = 0;
                }

                sum += (number % 10);
                number /= 10;
            }

            return sum == 1 ? true : false;
        }

        private static int getSumOfDigits(int number)
        {
            var totalDigits = getDigitsCount(number);

            var divisor = (int)Math.Pow(10, totalDigits - 1);
            var ans = 0;

            while (divisor != 0)
            {
                ans += number / divisor;

                number = number % divisor;
                divisor /= 10;
            }

            return ans;
        }

        private static int getDigitsCount(int number)
        {
            var count = 0;

            while (number != 0)
            {
                number /= 10;
                count++;
            }

            return count;
        }
    }
}

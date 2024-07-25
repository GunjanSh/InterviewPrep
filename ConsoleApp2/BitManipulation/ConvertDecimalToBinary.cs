using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.BitManipulation
{
    internal class ConvertDecimalToBinary
    {
        public static void ConvertToBinary()
        {
            Console.WriteLine(GetBinary(10)); // 1010

            Console.WriteLine(GetBinary(8)); // 1000
        }

        static string GetBinary(int number)
        {
            StringBuilder sb = new StringBuilder();

            for (int idx = 31; idx >= 0; idx--)
            {
                var setBit = (number >> idx) & 1;
                sb.Append(setBit);
            }

            return sb.ToString();
        }
    }
}

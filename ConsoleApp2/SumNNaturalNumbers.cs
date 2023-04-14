using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class SumNNaturalNumbers
    {
        public static int Sum(int number)
        {
            if (number == 0)
            {
                return 0;
            }

            return number + Sum(number - 1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class GrayCodeBinary
    {
        public static List<int> GrayCode(int number)
        {
            if (number == 1)
            {
                var blist = new List<int>();
                blist.Add(0);
                blist.Add(1);

                return blist;
            }

            var list = GrayCode(number - 1);
            var length = list.Count;

            for (var i = length - 1; i >= 0 ; i--)
            {
                var elem = list.ElementAt(i);
                list.Add(elem + length);
            }

            return list;
        }

        public static List<int> GrayCode2(int number)
        {
            var list = new List<int>();
            list.Add(0);
            list.Add(1);

            for (int i = 0; i < number; i++) // number = number of bits, 2^bits
            {
                var length = list.Count;

                for (int j = length - 1; j >= 0 ; j--)
                {
                    var elem = list.ElementAt(j);
                    list.Add(elem + (1 << i));
                }
            }

            return list;
        }
    }
}

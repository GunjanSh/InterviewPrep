using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class MergeTwoSortedArrays
    {
        public static List<int> solve(List<int> A, List<int> B)
        {
            var x = 0;
            var y = 0;
            var output = new List<int>();

            if (A == null && B == null)
            {
                return null;
            }

            var aLen = A.Count;
            var bLen = B.Count;

            while (x < aLen && y < bLen)
            {
                var aElem = A.ElementAt(x);
                var bElem = B.ElementAt(y);

                if (aElem <= bElem)
                {
                    output.Add(aElem);
                    x++;
                }
                else
                {
                    output.Add(bElem);
                    y++;
                }
            }

            while (x < aLen)
            {
                output.Add(A.ElementAt(x));
                x++;
            }

            while (y < bLen)
            {
                output.Add(B.ElementAt(y));
                y++;
            }

            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal static class ClimbStairsProb
    {
        internal static void ClimbStairs()
        {
            int stairs = 55007;
            //784052921
            var ways = Climber(stairs);
        }

        private static int Climber(int N)
        {
            long x = 1, y = 2, z;

            if (N == 0 || N == 1)
            {
                return N;
            }

            for (int i = 3; i <= N; i++)
            {
                z = x % 1000000007 + y % 1000000007;
                x = y;
                y = z;
            }

            return (int)y % 1000000007;
        }
    }
}

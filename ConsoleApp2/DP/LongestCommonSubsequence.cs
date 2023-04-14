using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    internal class LongestCommonSubsequence
    {
        public static void Solve()
        {
            string str1 = "abbcdf";
            string str2 = "babdcf";

            int len = Lcs(str1, str2);
            Console.WriteLine("Length of Lowest common subsequence for {0} and {1} is {2}", str1, str2, len);

            str1 = "aggtat";
            str2 = "gxtxayb";

            len = Lcs(str1, str2);
            Console.WriteLine("Length of Lowest common subsequence for {0} and {1} is {2}", str1, str2, len);
        }

        private static int Lcs(string str1, string str2)
        {
            int str1Len = str1.Length;
            int str2Len = str2.Length;

            int[,] dp = new int[str1Len + 1, str2Len + 1];

            for (int i = 0; i <= str1Len; i++)
            {
                for (int j = 0; j <= str2Len; j++)
                {
// 
                    if ( i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if(str1[i-1] == str2[j-1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[str1Len, str2Len];
        }
    }
}

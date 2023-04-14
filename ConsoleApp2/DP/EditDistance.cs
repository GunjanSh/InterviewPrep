using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    internal class EditDistance
    {
        public static void Solve()
        {
            //string str1 = "abad";
            //string str2 = "abac";  //1
            string str1 = "sunday";
            string str2 = "saturday";  //3

            int distance = MinDistance(str1, str2);
            Console.WriteLine("Minimum operations to convert {0} to {1} is {2}", str1, str2, distance);
        }

        private static int MinDistance(string str1, string str2)
        {
            int str1Len = str1.Length, str2Len = str2.Length;
            int[,] dp = new int[str1Len + 1, str2Len + 1];  //Length+1, as we are not considering the indices.

            // This is bottom up approach
            // if str1 = "", str2 = "abcde" - we need 5 operations
            // str1 = "abcd", str2 = "" -- we need 4 operations 
            // if (l1 == 0) return l2; 
            // if (l2 == 0) return l1;
            //This is row 0 and col 0, fill with index itself

            for (int i = 0; i <= str2Len; i++)
            {
                dp[0, i] = i;
            }

            for (int i = 0; i <= str1Len; i++)
            {
                dp[i, 0] = i;
            }

            for (int i = 1; i <= str1Len; i++)
            {
                for(int j = 1; j <= str2Len; j++)
                {
                    if (str1[i-1] == str2[j-1])  // when chars match, repeat for remaining chars in string
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        // when chars don't match, you have 3 options - replace, insert, delete in same order.
                        dp[i, j] = 1 + Math.Min(Math.Min(dp[i - 1, j - 1], dp[i, j - 1]), dp[i - 1, j]);
                    }
                }
            }

            return dp[str1Len, str2Len];
        }
    }
}

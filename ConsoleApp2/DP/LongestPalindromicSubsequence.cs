using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    /*
        Problem Description
        Given a string A. Find the longest palindromic subsequence (A subsequence which does not need to be contiguous and is a palindrome).

        You need to return the length of longest palindromic subsequence.

        Problem Constraints
        1 <= length of(A) <= 103
    */

    internal class LongestPalindromicSubsequence
    {
        public static void Solve()
        {
            string A = "bebeeed"; //4 - eeee
            string B = "aedsead"; //5 - aedea

            int len = LPS(A);
            Console.WriteLine(len);

            len = LPS(B);
            Console.WriteLine(len);
        }

        private static int LPS(string str)
        {
            int strLen = str.Length;
            //Since we are using indices directly of the str, use Length instead of Length+1.
            int[,] dp = new int[strLen, strLen];

            //Fill diagonal cells, consider them as subsequence of Length 1
            for (int i = 0; i < strLen; i++)
            {
                dp[i, i] = 1;
            }

            //Consider diagonals from the center diagonal of matrix.
            //Next diagonal will be all subsequence of length 2.
            //Next diagonal will be all subsequence of length 3 and so on.
            for (int len = 2; len <= strLen; len++)
            {
                //It is palindrome check, so consider only string from 0 to strLen-len. as we are checking all subsequence starting from 2 (diagonals).
                for (int i = 0; i <= strLen-len; i++)
                {
                    //check if this subsequence is a palindrome.
                    //range is [i...j] = len, j-i+1 = len --> j = len+i-1;
                    int start = i, end = i + len - 1;

                    // First and last char match.
                    if (str[start] == str[end])
                    {
                        //Add char length of first and last chars ie, 1+1 => 2 + (remaining string whose LPS is to be found).
                        dp[start, end] = 2 + dp[start + 1, end - 1];
                    }
                    else
                    {
                        //If first and last chars don't match, get the max of (start+1, end), (start, end+1).
                        dp[start, end] = Math.Max(dp[start + 1, end], dp[start, end - 1]);
                    }
                }
            }

            return dp[0, strLen - 1];
        }
    }
}

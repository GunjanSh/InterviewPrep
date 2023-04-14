using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    /// <summary>
    /// Implement wildcard pattern matching with support for ' ? ' and ' * ' for strings A and B.
    /// ' ? ' : Matches any single character.
    /// ' * ' : Matches any sequence of characters (including the empty sequence).
    /// The matching should cover the entire input string (not partial).
    /// </summary>
    internal class RegularExpressionMatch
    {
        public static void Solve()
        {
            string str = "axbc";
            string pattern = "a?b*c"; // true/1
            bool isMatched = IsMatch(str, pattern);
            Console.WriteLine("String {0} and pattern {1} are matching? - {2}", str, pattern, isMatched);

            str = "a";
            pattern = "?";// true/1

            isMatched = IsMatch(str, pattern);
            Console.WriteLine("String {0} and pattern {1} are matching? - {2}", str, pattern, isMatched);

            str = "aaa";
            pattern = "a*";// true/1

            isMatched = IsMatch(str, pattern);
            Console.WriteLine("String {0} and pattern {1} are matching? - {2}", str, pattern, isMatched);

            str = "acz";
            pattern = "a?a"; // false/0
            isMatched = IsMatch(str, pattern);
            Console.WriteLine("String {0} and pattern {1} are matching? - {2}", str, pattern, isMatched);

            str = "abcd";
            pattern = "***b**"; // false/0
            isMatched = IsMatch(str, pattern);
            Console.WriteLine("String {0} and pattern {1} are matching? - {2}", str, pattern, isMatched);

            str = "";
            pattern = "***b**"; // false/0
            isMatched = IsMatch(str, pattern);
            Console.WriteLine("String {0} and pattern {1} are matching? - {2}", str, pattern, isMatched);

            str = "";
            pattern = "*****"; // true/1
            isMatched = IsMatch(str, pattern);
            Console.WriteLine("String {0} and pattern {1} are matching? - {2}", str, pattern, isMatched);

            str = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            pattern = "*"; // true/1
            isMatched = IsMatch(str, pattern);
            Console.WriteLine("String {0} and pattern {1} are matching? - {2}", str, pattern, isMatched);
        }

        /// <summary>
        /// Bottom up approach.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static bool IsMatch(string str, string pattern)
        {
            int strLen = str.Length;
            int patternLen = pattern.Length;
            bool[,] dp = new bool[strLen + 1, patternLen + 1];

            dp[0, 0] = true;

            //If pattern is empty, there is nothing to match. Hence, return false.
            if (patternLen == 0) return false;
            if (strLen == 0)
            {
                // scenario where str = "" and pattern is "******" return true else false as pattern has char other than '*'
                for (int i = 0; i < patternLen; i++)
                {
                    if (pattern[i] != '*')
                        return false;
                }

                return true;
            }

            //Fill 1st row where str[s] = "" with pattern chars.
            //If pattern begins with '*', set col val to true until you find a char.
            //Once you find a char other than '*', set remaining col values to false
            for (int i = 0; i < patternLen; i++)
            {
                if (pattern[i] == '*')
                    dp[0, i+1] = true;
                else
                {
                    while(i < patternLen)
                    {
                        dp[0, i+1] = false;
                        i++;
                    }
                }
            }

            for (int s = 1; s <= strLen; s++)
            {
                for(int p = 1; p <= patternLen; p++) 
                {
                    //char in str and pattern are matching
                    //Or pattern is '?', can be replaced by 1 char, so get dp of s-1, p-1
                    if(str[s-1] == pattern[p-1] || pattern[p-1] == '?')
                    {
                        dp[s, p] = dp[s - 1, p - 1];
                    }
                    // char at pattern is '*', can be replaced by 0(s, p-1) or more chars(s-1, p) s-1 and pattern itself - can be used in future also.
                    else if (pattern[p-1] == '*')
                    {
                        dp[s, p] = dp[s - 1, p] || dp[s, p - 1];
                    }
                    // else pattern is not matched
                    else
                    {
                        dp[s, p] = false;
                    }
                }
            }

            return dp[strLen, patternLen];
        }
    }
}

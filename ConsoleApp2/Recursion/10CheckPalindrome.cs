using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class CheckPalindrome
    {
        public static void Check()
        {
            string str = "MADAM";

            bool isPalindrome = IsPalindrome(0, str);

            str = "MADAME";

            isPalindrome = IsPalindrome(0, str);
        }

        static bool IsPalindrome(int index, string str)
        {
            if (index >= str.Length/2)
            {
                return true;
            }

            if (str[index] != str[str.Length-index-1])
            {
                return false;
            }

            return IsPalindrome(index + 1, str);
        }
    }
}

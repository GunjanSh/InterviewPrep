using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Arrays
{
    internal class WordleWorking
    {
        public static void WordleGame()
        {
            var word = CreateWordle("APPLE");

            // -1 -1 -1 1 0
            var input = "BOOLA";
            var op1 = IsMatch(input, word);

            word = CreateWordle("APPLE");
            // -1 1 1 -1 0
            input = "OPPPA";
            var op2 = IsMatch(input, word);

            word = CreateWordle("APPLE");
            // -1 1 1 -1 -1
            input = "PPPPP";
            var op3 = IsMatch(input, word);
        }

        static List<int> IsMatch(string input, Dictionary<char, List<int>> charMap)
        {
            List<int> result = new List<int>(5);
            result = Enumerable.Repeat(-1, 5).ToList();

            for(int idx = 0; idx < input.Length; idx++)
            {
                var ch = input[idx];
                if (charMap.ContainsKey(ch) && charMap[ch].Exists(x => x == idx))
                {
                    result[idx] = 1;
                    charMap[ch].Remove(idx);
                }
            }

            for (int idx = 0; idx < input.Length; idx++)
            {
                var ch = input[idx];
                
                if (charMap.ContainsKey(ch) && charMap[ch].Any(x => x != idx))
                {
                    result[idx] = 0;
                }
            }

            return result;
        }

        static Dictionary<char, List<int>> CreateWordle(string word)
        {
            var map = new Dictionary<char, List<int>>();

            for (int idx = 0; idx < word.Length; idx++)
            {
                var ch = word[idx];

                if (!map.ContainsKey(ch))
                {
                    map[ch] = new List<int> { idx };
                }
                else
                {
                    map[ch].Add(idx);
                }
            }

            return map;
        }
    }
}

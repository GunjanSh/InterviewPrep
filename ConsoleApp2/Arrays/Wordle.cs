using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Arrays
{
    internal class Wordle
    {
        public static void WordleGame()
        {
            var word = CreateWordle("APPLE");

            // -1 -1 -1 1 0
            var input = "BOOLA";
            var op1 = IsMatch(word, input);

            word = CreateWordle("APPLE");
            // -1 1 1 -1 0
            input = "OPPPA";
            var op2 = IsMatch(word, input);

            word = CreateWordle("APPLE");
            // -1 1 1 -1 -1
            // 0 1 1 -1 -1 My output
            input = "PPPPP";
            var op3 = IsMatch(word, input);
        }

        static string IsMatch(List<int?>[] word, string input)
        {
            var output = new List<int?>();

            for (int idx = 0; idx < input.Length; idx++)
            {
                var ch = input[idx] - 'A';

                List<int?> list = word[ch];

                if (list == null)
                {
                    output.Add(-1);
                }
                else
                {
                    //APPLE
                    //BOOLA         --> -1 -1 -1 1 0
                    // var input = "OPPPA"; --> -1 1 1 -1 0
                    // var input = "PPPPP"; --> -1 1 1 -1 -1
                    //int? item = list.Where(x => x == idx).DefaultIfEmpty<int?>(null).First();
                    // Console.WriteLine("{0}: {1}", idx, item.HasValue);

                    var hasElem = list.Any(x => x == idx);

                    int? item = list.Where(x => x == idx).DefaultIfEmpty().First();
                   
                    if (hasElem && item.Value == idx)
                    {
                        output.Add(1);
                        list.Remove(idx);
                    }
                    else if (hasElem && item == null)
                    {
                        output.Add(-1);
                    }
                    else if (list.Count > 0 && !hasElem)
                    {
                        output.Add(0);
                    }
                    else
                    {
                        output.Add(-1);
                    }

                    //if (item == null)
                    //{
                    //    output.Add(-1);
                    //}
                    //else if (item.Value == idx)
                    //{
                    //    output.Add(1);
                    //    list.Remove(idx);
                    //}
                    // else
                    // {
                    //     output.Add(0);
                    // }
                }

                //if (list != null && list.Any(x => x == idx))
                //{
                //    output.Add(0);
                //}
            }

            Console.WriteLine("Output is {0}", string.Join(",", output));

            return string.Join(",", output);
        }

        static List<int?>[] CreateWordle(string word)
        {
            var wordList = new List<int?>[26];

            for (int idx = 0; idx < word.Length; idx++)
            {
                var ch = word[idx] - 'A';
                if (wordList[ch] == null)
                {
                    wordList[ch] = new List<int?> { idx };
                }
                else
                {
                    wordList[ch].Add(idx);
                }
            }

            return wordList;
        }

    }
}

/*
 *                        APPLE
 * List<int>[] --> 
 * [ch - 'A'] = new List<int> {0}
 * [ch - 'P'] = new List<int> {1, 2}
 * [ch - 'L'] = new List<int> {3}
 * [ch - 'E'] = new List<int> {4}
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Tries
{
    /*
     *  Given a phone directory in the form of string array A containing N numeric strings.
     *  If any phone number is prefix of another phone number then phone directory is invalid else it is valid.
     *  You need to check whether the given phone directory is valid or not if it is valid then return 1 else return 0.
     */

    internal class ValidPhoneDirectory
    {
        public static void Solve()
        {
            List<string> words = new List<string> { "1234", "2342", "567" };
            int output = solve(words);

            words = new List<string> { "00121", "001" };
            output = solve(words);
        }

        public static int solve(List<string> A)
        {
            TrieNodeNew root = new TrieNodeNew();

            foreach (string word in A)
            {
                if (!TrieNodeNew.Insert(root, word))
                {
                    return 0;
                }
            }
            return 1;
            //foreach (string word in A)
            //{
            //    TrieNodeNew.Insert(root, word);
            //}
            //bool isValid = true;
            //foreach (var word in A)
            //{
            //    isValid = isValid & TrieNodeNew.Search(root, word);
            //}

            //return isValid ? 1 : 0;
        }
    }

    public class TrieNodeNew
    {
        public TrieNodeNew[] Links = new TrieNodeNew[10];

        public int Count = 0;

        public bool IsEndOfNumber = false;

        public static bool ContainsKey(TrieNodeNew root, char ch)
        {
            return root.Links[ch - '0'] != null;
        }

        public static bool Insert(TrieNodeNew root, string word)
        {
            Console.WriteLine("root is {0}", root.Count);
            TrieNodeNew temp = root;
            int count = 0;

            foreach (char ch in word)
            {
                if (!ContainsKey(temp, ch))
                {
                    temp.Links[ch - '0'] = new TrieNodeNew();
                }
                else
                {
                    count++;
                }

                temp = temp.Links[ch - '0'];
                //temp.Count = temp.Count + 1;
            }

            temp.IsEndOfNumber = true;

            if (word.Length == count)
            {
                return false;
            }

            return true;
        }

        public static bool Search(TrieNodeNew root, string word)
        {
            TrieNodeNew temp = root;

            foreach (char ch in word)
            {
                if (ContainsKey(temp, ch) && temp.Links[ch - '0'].Count == 1)
                {
                    temp = temp.Links[ch - '0'];
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }

}

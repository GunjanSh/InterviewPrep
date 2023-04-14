using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Tries
{


    public class TrieNode
    {
        public TrieNode[] Links = new TrieNode[26];
        public int Count = 0;
        public char ch;
        public bool IsEndOfWord = false;

        public static bool ContainsKey(TrieNode root, char ch)
        {
            return root.Links[ch - 'a'] != null;
        }

        public static void Insert(TrieNode root, string word)
        {
            TrieNode temp = root;
            foreach (char ch in word)
            {
                if (!ContainsKey(temp, ch))
                {
                    temp.Links[ch - 'a'] = new TrieNode();
                }

                temp = temp.Links[ch - 'a'];
                temp.Count = temp.Count + 1;
                temp.ch = ch;
            }

            temp.IsEndOfWord = true;
        }

        public static int Search(TrieNode root, string word)
        {
            TrieNode temp = root;

            foreach (char ch in word)
            {
                if (!ContainsKey(temp, ch))
                {
                    return 0;
                }

                temp = temp.Links[ch - 'a'];
            }

            return temp.Count;
        }
    }

    internal class ContactFinder
    {
        public static void Solve()
        {
            List<int> actions = new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 };
            List<string> words = new List<string> { "s", "ss", "sss", "ssss", "sssss", "s", "ss", "sss", "ssss", "sssss", "ssssss" };

            //List<int> actions = new List<int> { 0, 1 };
            //List<string> words = new List<string> { "ab", "a" };

            var output = solve(actions, words);
        }
        public static List<int> solve(List<int> Actions, List<string> Words)
        {
            List<int> output = new List<int>();
            TrieNode root = new TrieNode();

            for (int idx = 0; idx < Words.Count; idx++)
            {
                int action = Actions[idx];

                switch (action)
                {
                    case 0:
                        TrieNode.Insert(root, Words[idx]);
                        break;
                    case 1:
                        output.Add(TrieNode.Search(root, Words[idx]));
                        break;
                }
            }

            return output;
        }
    }
}

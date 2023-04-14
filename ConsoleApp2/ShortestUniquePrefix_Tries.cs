using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class TrieNode
    {
        internal TrieNode[] Children = new TrieNode[26];

        internal bool IsEndOfWord = false;

        internal int Count = 0;
    }

    static internal class ShortestUniquePrefix_Tries
    {
        public static List<string> Prefix()
        {
            var list = new List<string> { "zebra", "dog", "duck", "dove" };
            //var list = new List<string> { "apple", "ball", "cat" };
            var root = new TrieNode();
            var prefixes = new List<string>();

            foreach (var word in list)
            {
                Insert(root, word);
            }

            foreach (var word in list)
            {
                var prefix = Search(root, word);
                prefixes.Add(prefix);
            }
    
            return prefixes;
        }

        private static void Insert(TrieNode root, string word)
        {
            var temp = root;

            foreach (var ch in word)
            {
                if (temp.Children[ch - 'a'] == null)
                {
                     temp.Children[ch - 'a'] = new TrieNode();
                }
                temp.Count += 1;
                temp = temp.Children[ch - 'a'];
            }

            temp.IsEndOfWord = true;
        }

        private static string Search(TrieNode root, string word)
        {
            var temp = root;
            var prefix = new StringBuilder();

            foreach (var ch in word)
            {
                if (temp.Children[ch - 'a'] == null) break;
                if (temp.Children[ch - 'a'].Count == 1)
                {
                    prefix.Append(ch);
                    break;
                }
                else
                {
                    prefix.Append(ch);
                    temp = temp.Children[ch - 'a'];
                }
            }

            return prefix.ToString();   
        }
    }
}

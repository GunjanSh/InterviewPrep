using ConsoleApp2.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Tries
{
    public class TrieNodeW
    {
        public Dictionary<char, TrieNodeW> Children;
        public bool IsWord;

        public TrieNodeW()
        {
            this.Children = new Dictionary<char, TrieNodeW>();
        }

        public void Insert(string word)
        {
            var currNode = this;

            foreach (char ch in word)
            {
                if (!currNode.Children.ContainsKey(ch))
                {
                    currNode.Children[ch] = new TrieNodeW();
                }

                currNode = currNode.Children[ch];
            }

            currNode.IsWord = true;
        }

        public bool Search(string word)
        {
            var currNode = this;

            foreach (char ch in word)
            {
                if (!currNode.Children.ContainsKey(ch))
                {
                    return false;
                }

                currNode = currNode.Children[ch];
            }

            return currNode.IsWord;
        }
    }

    internal class WordSearch_II___Using_Trie_and_BackTracking
    {
        public static void Search()
        {
            char[][] board = new char[][] { new char[] { 'o', 'a', 'a', 'n' }, new char[] { 'e', 't', 'a', 'e' }, new char[] { 'i', 'h', 'k', 'r' }, new char[] { 'i', 'f', 'l', 'v' } };
            string[] words = { "oath", "pea", "eat", "rain" };

            var output = FindWords(board, words);

            char[][] board2 =  new char[][] {new char[] { 'a','b','c'}, new char[] { 'a','e','d'}, new char[] { 'a','f','g'} };
            string[] words2 = { "abcdefg", "gfedcbaaa", "eaabcdgfa", "befa", "dgc", "ade"};
            //string[] words2 = { "gfedcbaaa", "eaabcdgfa", };

            output = FindWords(board2, words2);
        }

        static IList<string> FindWords(char[][] board, string[] words)
        {
            var obj = new WordSearch_II___Using_Trie_and_BackTracking();
            
            var trie = new TrieNodeW();
            TrieNodeW curr = trie;

            foreach (var word in words)
            {
                curr.Insert(word);
                //curr = trie;
            }

            int rowLen = board.Length, colLen = board[0].Length;
            bool[,] visited = new bool[rowLen, colLen];
            HashSet<string> output = new HashSet<string>();
            int[] rowIdxs = new int[] { -1, 0, 1, 0 };
            int[] colIdxs = new int[] { 0, -1, 0, 1 };

            for (int row = 0; row < rowLen; row++)
            {
                for (int col = 0; col < colLen; col++)
                {
                    if (!visited[row, col])
                    {
                        obj.Dfs(board, row, col, trie, rowIdxs, colIdxs, visited, output, string.Empty);
                    }
                }
            }

            return output.ToList();
        }

        void Dfs(char[][] board, int row, int col, TrieNodeW trie, int[] rowIdxs, int[] colIdxs, bool[,] visited, HashSet<string> output, string ongoingStr)
        {
            if (row < 0 ||
                    row >= board.Length ||
                    col < 0 ||
                    col >= board[0].Length ||
                    visited[row, col] ||
                    !trie.Children.ContainsKey(board[row][col]))
            {
                return;
            }

            visited[row, col] = true;

            ongoingStr += board[row][col];
            trie = trie.Children[board[row][col]];

            if (trie.IsWord)
            {
                output.Add(ongoingStr);
            }

            for (int idx = 0; idx < rowIdxs.Length; idx++)
            {
                var nr = row + rowIdxs[idx];
                var nc = col + colIdxs[idx];

                // if(nr < 0 ||
                //     nr > board.Length ||
                //     nc < 0 ||
                //     nc > board[0].Length ||
                //     visited[nr,nc] ||
                //     !trie.Children[board[nr][nc]])
                //     {
                //         return false;
                //     }

                //if (nr >= 0 && nr < board.Length && nc >= 0 && nc < board[0].Length)
                //{
                    Dfs(board, nr, nc, trie, rowIdxs, colIdxs, visited, output, ongoingStr);
                //}
            }

            visited[row, col] = false;

        }
    }
}

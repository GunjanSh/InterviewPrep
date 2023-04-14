using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2.Trees
{
    internal class MostFrequentElementInBST
    {
   //     ______10_________
   //        /                 \
   //    ___8___ __12__
   //   /       \            /      \
   //  6        9     10        12
   // / \       / \       /  \      /  \ 
   //6  7   9 10  10  11 12 13

        // https://www.geeksforgeeks.org/find-maximum-count-of-duplicate-nodes-in-a-binary-search-tree/
        // https://www.quora.com/How-can-you-count-all-the-duplicates-in-a-binary-search-tree-in-O-n-time-and-O-1-space
        // 
        public static void Solve()
        {
            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(8);
            root.right = new TreeNode(12);
            root.left.left = new TreeNode(6);
            root.left.right = new TreeNode(9);
            root.left.left.left = new TreeNode(6);
            root.left.left.right = new TreeNode(7);
            root.left.right.left = new TreeNode(9);
            root.left.right.right = new TreeNode(10);

            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(12);
            root.right.left.left = new TreeNode(10);
            root.right.left.right = new TreeNode(11);
            root.right.right.left = new TreeNode(12);
            root.right.right.right = new TreeNode(13);


            //TreeNode root = new TreeNode(6);
            //root.left = new TreeNode(5);
            //root.right = new TreeNode(7);
            //root.left.left = new TreeNode(4);
            //root.left.right = new TreeNode(5);
            //root.right.left = new TreeNode(7);
            //root.right.right = new TreeNode(7);

            int maxFrequency = inOrderMorris(root);
            Console.WriteLine(maxFrequency);

            int maxFreq = findnode(root);
            Console.WriteLine(maxFreq);
        }

        // cur for storing the current count
        // of the value and mx for the maximum count
        // of the element which is denoted by node
        static int cur = 1, mx = 0;
        static int node;
        static TreeNode previous = null;

        // Find the inorder traversal of the BST
        static void inorder(TreeNode root)
        {
            // If root is null then return
            if (root == null)
            {
                return;
            }
            inorder(root.left);
            if (previous != null)
            {

                // If the previous value is equal to
                // the current value then increase the count
                if (root.val == previous.val)
                {
                    cur++;
                }

                // Else initialize the count by 1
                else
                {
                    cur = 1;
                }
            }

            // If current count is greater than the
            // max count then update the mx value
            if (cur > mx)
            {
                mx = cur;
                node = root.val;
            }

            // Make the current Node as previous
            previous = root;
            inorder(root.right);
        }

        // Utility function
        static int findnode(TreeNode root)
        {
            inorder(root);
            return node;
        }

    static int inOrderMorris(TreeNode root)
        {
            TreeNode current = root;
            TreeNode prev = null;
            int maxCount = 0, maxCountNumber = root.val;
            int currCount = 0;

            while (current != null)
            {
                if (current.left == null)
                {
                    //process(current);

                    GetNumberWithMaxCount(current, prev, ref maxCount, ref maxCountNumber, ref currCount);

                    current = current.right;
                }
                else
                {
                    prev = current.left;

                    while (prev.right != null && prev.right != current)
                    {
                        prev = prev.right;
                    }

                    if (prev.right == null)
                    {
                        prev.right = current;
                        current = current.left;
                    }
                    else
                    {
                        prev.right = null;
                        //process(current);

                        GetNumberWithMaxCount(current, prev, ref maxCount, ref maxCountNumber, ref currCount);
                        current = current.right;
                    }
                }
            }

            return maxCountNumber;
        }

        static void GetNumberWithMaxCount(TreeNode current, TreeNode prev, ref int maxCount, ref int maxCountNumber, ref int currCount)
        {
            if (current.val == prev?.val)
            {
                currCount++;
            }
            else
            {
                currCount = 1;
            }

            if (currCount > maxCount)
            {
                maxCount = currCount;
                maxCountNumber = current.val;
            }
        }
    }
}

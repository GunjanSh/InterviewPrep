using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Trees
{
    internal class ConstructTreeFromInorderAndPreorder
    {
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return CreateTree(preorder.ToList(), inorder.ToList());
        }

        public static TreeNode CreateTree(List<int> preorder, List<int> inorder)
        {
            if (preorder.Count == 0 || inorder.Count == 0)
            {
                return null;
            }

            var rootVal = preorder[0];
            var root = new TreeNode(rootVal);

            var index = inorder.IndexOf(rootVal);

            root.left = CreateTree(preorder.Skip(1).ToList(), inorder.Take(index).ToList());
            root.right = CreateTree(preorder.Skip(index+1).ToList(), inorder.Skip(index + 1).ToList());

            return root;
        }
    }
}

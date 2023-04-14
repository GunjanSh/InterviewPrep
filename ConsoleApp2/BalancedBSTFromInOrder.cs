using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class TreeNode
    {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { this.val = x; this.left = this.right = null; }
     }
    internal static class BalancedBSTFromInOrder
    {
        public static TreeNode CreateBalancedBST()
        {
            List<int> list = new List<int> { 1, 4, 8 };
            return sortedArrayToBST(list);
        }
    
        private static TreeNode sortedArrayToBST(List<int> list)
        {
            return CreateBalancedTree(list, 0, list.Count-1);
        }

        private static TreeNode CreateBalancedTree(List<int> list, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            if (left == right)
            {
                return new TreeNode(list[left]);
            }

            int mid = (left + right) / 2;
            Console.WriteLine("Left {0}, Right: {1}, Mid {2}", left, right, list[mid]);
            TreeNode root = new TreeNode(list.ElementAt(mid));

            root.left = CreateBalancedTree(list, left, mid-1);
            root.right = CreateBalancedTree(list, mid + 1, right);

            return root;
        }
    }
}

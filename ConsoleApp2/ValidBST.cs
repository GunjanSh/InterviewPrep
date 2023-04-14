using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal static class ValidBST
    {
        internal static void ValidateBst()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            var isBst = IsValidBst(root, int.MinValue, int.MaxValue);
            Console.WriteLine(isBst);     //False

            root = new TreeNode(2);
            root.left = new TreeNode(1);
            root.right = new TreeNode(3);

            isBst = IsValidBst(root, int.MinValue, int.MaxValue);
            Console.WriteLine(isBst);        //True
        }

        static bool IsValidBst(TreeNode root, int leftMin, int rightMax)
        {
            if (root == null)
            {
                return true;
            }

            if (root.val < leftMin || root.val > rightMax)
            {
                return false;
            }

            return IsValidBst(root.left, leftMin, root.val - 1) &&
                        IsValidBst(root.right, root.val + 1, rightMax);
        }
    }
}

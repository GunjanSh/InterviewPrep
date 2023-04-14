using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Trees
{
    internal class RecoverBinarySearchTree
    {
        public static void Solve()
        {
            TreeNode node = new TreeNode(76);
            node.left = new TreeNode(77);

            List<int> list = new List<int>();
            bool firstInversionPairFound = true;
            int prev = int.MinValue;

            //81 90 83 93 76 84 92 101 75 82 -1 89 91 -1 98 111 -1 -1 79 -1 87 -1 -1 -1 94 100 -1 108 78 80 85 88 -1 95 99 -1 106 110 77 -1 -1 81 -1 86 -1 -1 -1 96 -1 -1 104 107 109 112 -1 -1 -1 -1 -1 -1 -1 97 103 105 -1 -1 -1 -1 102 114 -1 -1 -1 -1 -1 -1 -1 -1 113 -1 -1 -1

            InOrder(node, list, ref firstInversionPairFound, ref prev);
        }

        static void InOrder(TreeNode root, List<int> list, ref bool firstInversionPairFound, ref int prev)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left, list, ref firstInversionPairFound, ref prev);

            if (root.val < prev && firstInversionPairFound)
            {
                Console.WriteLine("In if, maxDip {0} , minDip {1}", prev, root.val);
                list.Add(root.val); //minDip
                list.Add(prev); // maxDip
                firstInversionPairFound = false;
            }
            else if (root.val < prev && !firstInversionPairFound)
            {
                Console.WriteLine("In Else if, maxDip {0} , minDip {1}", prev, root.val);
                list[0] = root.val;
            }

            prev = root.val;
            InOrder(root.right, list, ref firstInversionPairFound, ref prev);
        }
    }
}

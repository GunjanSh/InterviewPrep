using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal static class ReverseEveryKNodes
    {
        internal static void ReverseNodes()
        {
            var node = new ListNode(1, null);
            node.next = new ListNode(2, null);
            node.next.next = new ListNode(3, null);
            node.next.next.next = new ListNode(4, null);
            node.next.next.next.next = new ListNode(5, null);

            var reversedNode = Reverse(node, 3);
        }

        private static ListNode Reverse(ListNode head, int nodesToReverse)
        {
            ListNode curr = head, prev = null, next = null;
            int count = 0;

            while(curr != null && count < nodesToReverse)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
                count++;
            }

            if (next != null)
            {
                head.next = Reverse(next, nodesToReverse);
            }

            return prev;
        }
    }
}

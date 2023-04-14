using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class ReverseBetweenTwoNodes
    {
        public static ListNode ReverseBetween(ListNode A, int B, int C)
        {
            ListNode dummy = new ListNode(next: A);

            ListNode leftPrev = dummy, currNode = A;

            for (int i = 0; i < B-1; i++)
            {
                leftPrev = currNode;
                currNode = currNode.next;
            }

            int toRotate = (C - B + 1);

            ListNode prev = null, next = null, curr = currNode;
            for (int i = 0; i < toRotate; i++)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            leftPrev.next.next = curr;
            leftPrev.next = prev;
            
            return dummy.next;
        }
    }
}

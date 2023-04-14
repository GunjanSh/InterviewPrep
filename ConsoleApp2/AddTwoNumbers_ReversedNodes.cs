using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.MS
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
     }

    public static class AddTwoNumbers_ReversedNodes
    {
        public static void AddTwoLinkedListInReverse()
        {
            int[] list1 = new int[] { 2, 4, 3 };
            int[] list2 = new int[] { 5, 6, 4, 1 };
            // Expected output --> After reversing ---> 708

            //Input: l1 = [9, 9, 9, 9, 9, 9, 9], l2 = [9, 9, 9, 9]
            //Output:[8,9,9,9,0,0,0,1]

            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4, new ListNode(1, null))));

            int[] list3 = new int[] { 9, 9, 9, 9, 9, 9, 9 };
            int[] list4 = new int[] { 9, 9, 9, 9 };

            //ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            //ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));

            ListNode addedNodes = AddTwoNumbers(l1, l2);

            while (addedNodes != null)
            {
                Console.WriteLine(addedNodes.val);
                addedNodes = addedNodes.next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0, null);
            ListNode temp = dummy;

            int carry = 0;

            while (l1 != null || l2 != null || carry == 1)
            {
                int sum = (l1 == null? 0 : l1.val) + (l2 == null? 0 : l2.val) + carry; // Add null check if length of both lists is not same, it will handle case.
                carry = sum / 10;  // Add carry to the right instead of left

                int val = sum % 10;

                temp.next = new ListNode(val, null);
                temp = temp.next;

                if (l1 != null)
                {
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }

            return dummy.next;
        }
    }
}

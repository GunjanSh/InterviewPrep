using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.LinkedList
{
    internal class ReorderList
    {
        public static void Solve()
        {

            ListNode listNode = new ListNode(1);
            listNode.next = new ListNode(2);
            listNode.next.next = new ListNode(3);
            listNode.next.next.next = new ListNode(4);
            //listNode.next.next.next.next = new ListNode(5);

            var head = ReorderListNodes(listNode);
            Console.WriteLine("Reordered list");
            //85 90 94 25 51 45 29 55 63 48 27 72 10 36 68 16 20 31 7 95 70 89 23 22 9 74 71 35 5 80 11 49 92 69 6 37 84 78 28 43 64 96 57 83 13 73 97 75 59 53 52 19 18 98 12 81 24 15 60 79 34 1 54 93 65 44 4 87 14 67 26 30 77 58 85 33 21 46 82 76 88 66 101 61 47 8
        }

        public static ListNode ReorderListNodes(ListNode A)
        {
            if (A == null || A.next == null || A.next?.next == null)
            {
                return A;
            }

            ListNode midNode = FindMidOfList(A);
            ListNode head2 = midNode.next;
            midNode.next = null;

            ListNode reversedList = ReverseList(head2);

            ListNode finalHead = Merge(A, reversedList);
            return finalHead;
        }

        private static ListNode Merge(ListNode head1, ListNode head2)
        {
            ListNode p1 = head1, p2 = head2;
            ListNode head = null, tail = null;

            while (p1 != null && p2 != null)
            {
                if (head == null)
                {
                    head = p1;
                    tail = p1;
                    //p1 = p1.next;
                }
                else
                {
                    tail.next = p1;
                    //p1 = p1.next;
                    tail = p1;
                }
                p1 = p1.next;

                tail.next = p2;
                tail = p2;
                p2 = p2.next;
            }

            if (p1 != null)
            {
                tail.next = p1;
            }

            return head;
        }

        private static ListNode FindMidOfList(ListNode node)
        {
            ListNode slow = node, fast = node;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        private static ListNode ReverseList(ListNode head)
        {
            ListNode currNode = head, next = null, prev = null;

            while (currNode != null)
            {
                next = currNode.next; // Save next ptr before updating
                currNode.next = prev; // Set next ptr to previous node
                prev = currNode; // Move previous pointer ahead        
                currNode = next; // Move next pointer ahead
            }

            return prev;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Xml;
///https://leetcode.com/problems/reverse-linked-list-ii/
///STEPS TO REVERSE LINKED LIST
///-(1) Get the current node
///-(2) store next value
///-(3) update next value to list sofar
///-(4) store current node as list sofar
///-(5) update current node to stored to stored to next value at (2)
namespace FAANGInterviewQuestions.LinkedList
{
    public static class ReverseBetweenSol
    {
        public static void Execute()
        {
            var n1 = new ListNode(1);
            var n2 = new ListNode(2);
            var n3 = new ListNode(3);
            var n4 = new ListNode(4);
            var n5 = new ListNode(5);
            var n6 = new ListNode(6);
            var n7 = new ListNode(7);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            n6.next = n7;

            var head = n1;
            var current = head;
            Console.WriteLine("Origin List:");

            while (current != null)
            {
                Console.Write($"{current.val} -> ");
                current = current.next; 
            }

            Console.WriteLine("null");
            //var reversedListHead = ReverseLinkedList(head);
            var reversedListHead = ReverseBetween(head, 2, 4);
            current = reversedListHead;
            Console.WriteLine("Reversed List:");

            while (current != null)
            {
                Console.Write($"{current.val} -> ");
                current = current.next;
            }
            Console.Write("null");
        }
        public static void Execute1()
        {
            var A = new NodeChar('A');
            var B = new NodeChar('B');
            var C = new NodeChar('C');
            var D = new NodeChar('D');

            A.next = B;
            B.next = C;
            C.next = D;

            PrintList(A);
            PrintListRecursive(A);
            Console.WriteLine(string.Join(",", GetLinkedListValues(A)));
            var values = new List<char>();
            GetLinkedListValuesRecursive(A, values);
            Console.WriteLine(string.Join(",", values ));

        }
        public static void PrintList(NodeChar head)
        {
            NodeChar current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void PrintListRecursive(NodeChar head)
        {
            if(head == null)
            {
                Console.WriteLine("null");
                return;
            };
            Console.Write(head.val + " -> ");
            PrintListRecursive(head.next);
        }

        public static List<char> GetLinkedListValues(NodeChar head)
        {
            var values = new List<char>();
            var current = head;
            while(current != null)
            {
                values.Add(head.val);
                current = current.next;
            }

            return values;
        }

        public static void GetLinkedListValuesRecursive(NodeChar head, List<char> values)
        {
            if (head == null) return;
            values.Add(head.val);
            GetLinkedListValuesRecursive(head.next, values);
        }
        public static ListNode ReverseLinkedList(ListNode head)
        {
            ListNode current = head;
            ListNode previous = null;
            while(current != null)
            {
                var temp = current.next;
                current.next = previous;
                previous = current;
                current = temp;
            }
            return previous;
        }
        public static ListNode ReverseBetween(ListNode head, int left, int right)
        {
            ListNode currentNode = head;
            int currentPosition = 1;
            ListNode start = head;
            while(currentPosition  < left)
            {
                start = currentNode;
                currentNode = currentNode.next;
                currentPosition++;
            }
            ListNode newList = null;
            ListNode tail = currentNode;
            while(currentPosition >= left && currentPosition <= right)
            {
                var next = currentNode.next;
                currentNode.next = newList;
                newList = currentNode;
                currentNode = next;
                currentPosition++;
            }
            start.next = newList;
            tail.next = currentNode;

            if(left > 1)
            {
                return head;
            }
            else
            {
                return newList;
            }


        }
    }

    public class ListNode
    {
        public readonly int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class NodeChar
    {
        public char val;
        public NodeChar next;
        public NodeChar(char val = ' ', NodeChar next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}

namespace FAANGInterviewQuestions.LinkedList
{
    /// <summary>
    /// https://leetcode.com/problems/linked-list-cycle-ii/description/
    /// </summary>
    public static class LinkedListCycle
    {
        public static void Execute()
        {
            // [3,2,0,-4]
            var n1 = new ListNode(3);
            var n2 = new ListNode(2);
            var n3 = new ListNode(0);
            var n4 = new ListNode(-4);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n2;

            PrintList(n1);
            var n = DetectCycle(n1);
            Console.WriteLine(n.val);
            var nf = DetectCycle2(n1);
            Console.WriteLine(nf.val);

        }

        public static void PrintList(ListNode head)
        {
            var index = 0;
            ListNode current = head;
            while (current != null && index <= 5)
            {
                Console.Write(current.val + " ->");
                current = current.next;
                index ++;   
            }
            Console.WriteLine("null");

        }

        // T : O(N)
        // S : O(N)
        public static ListNode DetectCycle(ListNode head)
        {
            ListNode current = head;
            var nodes = new List<ListNode>();
            while (current != null)
            {
                if (!nodes.Contains(current))
                {
                    nodes.Add(current);
                    current = current.next;
                }
                else
                {
                    return current;
                }
            }
            return null;

        }
        //Floyd's Tortoise and Hair Algorithm
        // T : O(N)
        // S : O(1)
        public static ListNode DetectCycle2(ListNode head)
        {
            ListNode current = head;
            ListNode meetingNode = head;
            var t = head;
            var h = head;
            
            while (h != null && h.next != null)
            {
                t = t.next;
                h = h.next.next;
                if(t == h)
                {
                    meetingNode = h;
                    break;
                }
            }
            while (meetingNode != current)
            {
                meetingNode = meetingNode.next;
                current = current.next;
            }
            return (head != null && head.next != null) ? current : null;

        }
    }
}

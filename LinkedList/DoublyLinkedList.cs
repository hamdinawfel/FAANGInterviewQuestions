namespace FAANGInterviewQuestions.LinkedList
{
    /// <summary>
    /// https://leetcode.com/problems/flatten-a-multilevel-doubly-linked-list/description/
    /// </summary>
    public static class DoublyLinkedList
    {
        public static void Execute()
        {
            var n1 = new Node { val = 1, prev = null , next = null, child = null };
            var n2 = new Node { val = 2, prev = null, next = null, child = null };
            var n3 = new Node { val = 3, prev = null, next = null, child = null };


            n1.child = n2;
            n2.child = n3;
            

            var head = n1;
            var current = head;
            PrintList(current);
            var n = Flatten(current);
            PrintList(n);
        }

        public static void PrintList(Node head)
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.val + " ->");
                current = current.next;
            }
            Console.WriteLine("null");
           
        }
        public static Node Flatten(Node head)
        {
           Node currentNode = head;
           Node childNode = null;
            while (currentNode != null)
            {
                if (currentNode.child != null)
                {
                    childNode = currentNode.child;
                    while (childNode.next != null)
                    {
                        childNode = childNode.next;
                    }
                    var temp = currentNode.next;
                    currentNode.child.prev = currentNode;
                    if(currentNode.next != null){
                        currentNode.next.prev = childNode;
                    }
                    currentNode.next = currentNode.child;
                    currentNode.child = null;
                    childNode.next = temp;
                    

                    currentNode = currentNode.next;
                }
                else
                {
                    currentNode = currentNode.next;
                }
            }
            return head;
        }
    }

    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;
    }
}

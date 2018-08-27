using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.head = new Node(50);
            list.head.next = new Node(20);
            list.head.next.next = new Node(15);
            list.head.next.next.next = new Node(4);
            list.head.next.next.next.next = new Node(10);

            // Creating a loop for testing 
            list.head.next.next.next.next.next = list.head.next.next;
            list.detectAndRemoveLoop(list.head);
            Console.WriteLine("Linked List after removing loop : ");
            list.printList(list.head);
            Console.ReadLine(); 
        }
    }

    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
    class LinkedList
    {
        public Node head;
        // Function to print the linked list
        public void printList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
        }
        // Function that detects loop in the list
        public void detectAndRemoveLoop(Node node)
        {
            // If list is empty or has only one node
            // without loop
            if (node == null || node.next == null)
                return;
            Node slow = node, fast = node;

            // Move slow and fast 1 and 2 steps
            // ahead respectively.
            slow = slow.next;
            fast = fast.next.next;

            // Search for loop using slow and fast pointers
            while (fast != null && fast.next != null)
            {
                if (slow == fast)
                    break;

                slow = slow.next;
                fast = fast.next.next;
            }

            /* If loop exists */
            if (slow == fast)
            {
                Console.WriteLine("Loop exists"); 
                slow = node;
                while (slow.next != fast.next)
                {
                    slow = slow.next;
                    fast = fast.next;
                }

                /* since fast->next is the looping point */
                fast.next = null; /* remove loop */
                return;
            }
        }
    }
}

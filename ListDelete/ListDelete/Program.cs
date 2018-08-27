using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList l = new LinkedList();
            ListNode firstNode = l.Add(null, 1);
            firstNode = l.Add(firstNode, 3);
            firstNode = l.Add(firstNode, 3);
            firstNode = l.Add(firstNode, 4);
            firstNode = l.Add(firstNode, 5);
            firstNode = l.Add(firstNode, 5);
            //   firstNode = l.Add(firstNode, 1);
            l.firstNode = firstNode; 
            Console.WriteLine("Current LinkedList is as below");
            l.printList();
            Console.WriteLine("\nFirstNode is " + l.firstNode.val);
            Solution s = new Solution();
            l.firstNode = s.deleteDuplicates(l.firstNode);
            Console.WriteLine("After Dedup LinkedList is as below");
            l.printList();
            Console.ReadLine();

        }
    }

 class LinkedList
    {
        public ListNode firstNode; 
        public ListNode Add(ListNode givenNode, int data)
        {
            ListNode temp = givenNode; 
            if (temp == null)
            {
                ListNode l = new ListNode(data);
                return l;
            } else {
                //Get the place for node 
                while (temp.next != null)
                {
                    temp = temp.next;
                }

                ListNode m = new ListNode(data);
                temp.next = m;
                return givenNode;
                
            }
        }
        public void printList()
        {
            ListNode tempNode = this.firstNode;
            while (tempNode !=null)
            {
                Console.Write(" " + tempNode.val);
                tempNode = tempNode.next; 
            }
        }

    }
    
 class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) {this.val = x; this.next = null;}
  }
     class Solution
    {
        public ListNode deleteDuplicates(ListNode A)
        {
            ListNode firstNode = A;
         //   Console.WriteLine("1. A is " + A.val);
           // Console.WriteLine("1. A.next is " + A.next.val);
            while (A != null && A.next != null)
            {
                ListNode prev = A; 
                while ((A != null) && (A.next != null) && (A.val == A.next.val))
                {
                    A = A.next.next;
                }
                if (A != null)
                {
                    A = A.next;
                }                 
               
            }
            return A;
        }
    }

}

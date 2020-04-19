using System;

namespace Study
{
    class Program
    {
        int input = 10;
        Program p = new Program();


        //public Delegate void testDelegate();
        static void Main(string[] args)
        {
            /*
            object val = 5;
            Parameters p = new Parameters();

            Employee e = new Employee();
            e.EmployeeId = 5;

            //p.ReferenceParameter(ref val);
            p.NormalParameter(e);

            Console.WriteLine(e.EmployeeId);


            Console.ReadLine();
            */
            /*
            SingleLinkList<int> singleLinkList = new SingleLinkList<int> ();
            singleLinkList.AddAtHead(5);
            singleLinkList.AddAtHead(4);
            singleLinkList.AddAtHead(3);
            singleLinkList.AddAtHead(2);
            singleLinkList.AddAtHead(1);
            singleLinkList.AddAtIndex(1, 10);
            singleLinkList.DeleteAtIndex(2);

            //foreach (var item in singleLinkList)
            //{

            //}

            var head = singleLinkList.Current;
            while (head != null)
            {
                Console.WriteLine(head.Data);
                head = head.Next;
            }
            Console.ReadLine();
            */

            //[3,2,0,-4]
            //1
            MyLinkedList myLinkedList = new MyLinkedList();
            MyLinkedList.Node node = new MyLinkedList.Node(3, null);
            node.Next = new MyLinkedList.Node(2, null);
            node.Next.Next = new MyLinkedList.Node(0, null);
            node.Next.Next.Next = new MyLinkedList.Node(-4, node.Next.Next);

             var test  = DetectCycle(node);
            
            Console.ReadLine();
        }

        public static MyLinkedList.Node DetectCycle(MyLinkedList.Node head)
        {


            /*if(head == null || head.next == null)
                return null;
            else
            {
                ListNode slow = head;
                ListNode fast = head.next;
                while(slow != fast)
                {
                    if(fast == null || slow == null)
                        return null;

                    slow = slow.next;
                    fast = fast.next?.next;
                }


                return slow;
            }*/

            MyLinkedList.Node slow = head;
            MyLinkedList.Node fast = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                { // they collided
                    MyLinkedList.Node slow2 = head;
                    while (slow2 != slow)
                    {
                        slow = slow.Next;
                        slow2 = slow2.Next;
                    }
                    return slow;
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public class MyLinkedList
    {

        /** Initialize your data structure here. */
        public MyLinkedList()
        {

        }

        int size = 0;
        public Node head = null;
        public Node tail = null;

        public Node Current => head;

        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data, Node next)
            {
                this.Data = data;
                this.Next = next;
            }
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index < size)
            {
                var traverse = head;
                for (int i = 0; i < index; i++)
                {
                    traverse = traverse.Next;
                }
                return traverse.Data;
            }
            return -1;

        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            Node newNode = new Node(val, head);
            head = newNode;
            size++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            var traverse = head;
            while (traverse.Next != null)
            {
                traverse = traverse.Next;
            }
            traverse.Next = new Node(val, null);
            size++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (size == 0 || index == 0)
            {
                AddAtHead(val);
                return;
            }
                

            if (index <= size)
            {
                var traverse = head;
                for (int i = 0; i < index -1 ; i++)
                {
                    traverse = traverse.Next;
                }
                Node newNode = new Node(val, traverse.Next);
                traverse.Next = newNode;
                size++;
            }
            else
                AddAtTail(val);

        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            var traverse = head;
            if (index < size)
            {
                if(index == 0)
                {
                    head = head.Next;
                }
                else
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        traverse = traverse.Next;
                    }
                    traverse.Next = traverse.Next == null ? null : traverse.Next.Next;
                    
                }

                size--;

            }

        }
    }
}

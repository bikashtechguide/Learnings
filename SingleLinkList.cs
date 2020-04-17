using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public class SingleLinkList<T> //: IEnumerator
    {
        int size = 0;
        Node<T> head = null;
        Node<T> tail = null;

        public Node<T> Current => head;

        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }
            public Node(T data, Node<T> next)
            {
                this.Data = data;
                this.Next = next;
            }
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public T Get(int index)
        {
            var traverse = head;
            for (int i = 0; i < index; i++)
            {
                traverse = traverse.Next;
            }
            return traverse.Data;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(T val)
        {
            if (size == 0)
                head = tail = new Node<T>(val, null);
            else
            {
                Node<T> current = new Node<T>(val, head);
                head = current;
                
            }

            size++;

        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(T val)
        {
            if (size == 0)
                tail = head = new Node<T>(val, null);
            else
            {
                Node<T> current = new Node<T>(val, null);
                tail.Next = new Node<T>(val, current);
                
            }
            size++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, T val)
        {
            if (index > size)
                return;

            else
            {
                Node<T> traverse = head;
                for (int i = 0; i < index-1; i++)
                {
                    traverse = head.Next;
                }
                var newNode = new Node<T>(val, traverse.Next);
                traverse.Next = newNode;
            }

        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index > size)
                return;
            else if(index ==0)
            {
                var temp = head;
                head = null;
                head = temp.Next;
            }
            else if(index == size)
            {
                var temp = tail;

            }
            else
            {
                Node<T> traverse = head;
                for (int i = 0; i < index-1; i++)
                {
                    traverse = traverse.Next;
                }
                traverse.Next = traverse.Next.Next;
            }
        }
    }


}

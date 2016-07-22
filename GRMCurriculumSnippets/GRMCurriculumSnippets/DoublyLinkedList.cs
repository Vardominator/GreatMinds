using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMCurriculumSnippets
{
    class DoublyLinkedList<T>
    {

        LNode<T> head;
        LNode<T> tail;
        int count;

        public int Count { get { return count; } }

        public DoublyLinkedList()
        {
            head = new LNode<T>();
            tail = new LNode<T>();
            head.Next = tail;
            tail.Prev = head;
        }


        public void AddToEnd(T value)
        {
            LNode<T> newNode = new LNode<T>(value);

            if (head.Next == tail)
            {
                head.Next = newNode;
                newNode.Prev = head;
                newNode.Next = tail;
                tail.Prev = newNode;
            }
            else
            {
                LNode<T> lastNode = tail.Prev;
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
                newNode.Next = tail;
                tail.Prev = newNode;
            }
            count++;
        }

        public void AddToFront(T value)
        {

            LNode<T> newNode = new LNode<T>(value);
            if (head.Next == tail)
            {
                head.Next = newNode;
                newNode.Prev = head;
                newNode.Next = tail;
                tail.Prev = newNode;
            }
            else
            {
                LNode<T> lastFirstNode = head.Next;
                newNode.Next = lastFirstNode;
                newNode.Prev = head;
                head.Next = newNode;
            }
            count++;

        }

        public void RemoveFromEnd()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException("List is empty.");
            }

            LNode<T> nodeToRemove = tail.Prev;
            LNode<T> newLastNode = nodeToRemove.Prev;

            newLastNode.Next = tail;
            tail.Prev = newLastNode;
        }

        public void RemoveFromFront()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException("List is empty");
            }

            LNode<T> nodeToRemove = head.Next;
            LNode<T> newFirstNode = nodeToRemove.Next;

            newFirstNode.Prev = head;
            head.Next = newFirstNode;
        }

        public void RemoveAt(int position)
        {
            if (IsEmpty())
            {
                throw new NullReferenceException("List is empty.");
            }
            else if(position > count - 1 || position < 0)
            {
                throw new ArgumentOutOfRangeException("Input position is out of range.");
            }

            if(position == 0)
            {
                RemoveFromFront();
            }
            else if(position == count - 1)
            {
                RemoveFromEnd();
            }
            else
            {
                LNode<T> current = head.Next;
                for (int i = 0; i < position - 1; i++)
                {
                    current = current.Next;
                }
            }
        }

        public bool IsEmpty()
        {
            return head.Next == tail;
        }

        public override string ToString()
        {
            LNode<T> current = head.Next;
            string list = "";
            while (current.Next != tail)
            {
                list += current.Val + " ";
                current = current.Next;
            }
            list += current.Val;
            return list;
    
        }
        
    }
}

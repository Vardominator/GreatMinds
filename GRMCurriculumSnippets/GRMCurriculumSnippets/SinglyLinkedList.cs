using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMCurriculumSnippets
{
class SinglyLinkedList<T>
{

    SNode<T> head;
    int count;

    public int Count { get; }

    public SinglyLinkedList()
    {
        head = new SNode<T>();
        head.Next = null;
        count = 0;
    }

    public void AddToEnd(T value)
    {

        
        SNode<T> newNode = new SNode<T>(value);

        if (head.Next == null)
        {
            head.Next = newNode;
        }

        else
        {

            SNode<T> current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;

        }
        count++;

    }

    public void AddToFront(T value)
    {

        SNode<T> newNode = new SNode<T>(value);

        if (head.Next == null)
        {
            head.Next = newNode;
        }


        SNode<T> oldFirstNode = head.Next;

        head.Next = newNode;
        newNode.Next = oldFirstNode;

        count++;

    }

    public void RemoveFromFront()
    {
        if (IsEmpty())
        {
            throw new NullReferenceException("List is empty.");
        }
        head.Next = head.Next.Next;
        count--;
    }

    public void RemoveFromEnd()
    {
        if (IsEmpty())
        {
            throw new NullReferenceException("List is empty.");
        }
        SNode<T> current = head.Next;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }
        current.Next = null;
        count--;
    }


    public void RemoveAt(int position)
    {
        if (IsEmpty())
        {
            throw new NullReferenceException("List is empty.");
        }
        else if (position > count - 1)
        {
            throw new ArgumentOutOfRangeException("Input position exceeds list count.");
        }

        if (position == 0)
        {
            RemoveFromFront();
        }
        else if (position == count - 1)
        {
            RemoveFromEnd();
        }
        else
        {
            SNode<T> current = head.Next;
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }
    }


    public bool IsEmpty()
    {
        return head.Next == null;
    }


    public override string ToString()
    {

        SNode<T> current = head.Next;
        string list = "";
        while (current.Next != null)
        {
            list += current.Val + " ";
            current = current.Next;
        }
        list += current.Val;
        return list;
    }

}
}

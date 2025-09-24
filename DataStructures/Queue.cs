namespace DataStructures;

public class Queue
{
    public Node? First;
    public Node? Last;
    public int Length;

    public class Node(int value)
    {
        public int Value = value;
        public Node? Next;
    }

    public Queue(int value)
    {
        Node newNode = new(value);
        First = newNode;
        Last = newNode;
        Length = 1;
    }

    public void Enqueue(int value)
    {
        Node newNode = new(value);

        if (Last is null)
        {
            First = newNode;
            Last = newNode;
        }
        else
        {
            Last.Next = newNode;
            Last = newNode;
        }

        Length++;
    }

    public Node? Dequeue()
    {
        if (First is null) return null;

        Node temp = First;

        if (Length == 1)
        {
            First = null;
            Last = null;
        }
        else
        {
            First = First.Next;
            temp.Next = null;
        }

        Length--;

        return temp;
    }
}
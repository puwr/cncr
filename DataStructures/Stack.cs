namespace DataStructures;

public class Stack
{
    public Node? Top;
    public int Height;

    public class Node(int value)
    {
        public int Value = value;
        public Node? Next;
    }

    public Stack(int value)
    {
        Node newNode = new(value);
        Top = newNode;
        Height = 1;
    }

    public void Push(int value)
    {
        Node newNode = new(value);

        if (Top is null)
        {
            Top = newNode;
        }
        else
        {
            newNode.Next = Top;
            Top = newNode;
        }

        Height++;
    }

    public Node? Pop()
    {
        if (Top is null) return null;

        Node temp = Top;
        Top = Top.Next;
        temp.Next = null;

        Height--;

        return temp;
    }
}
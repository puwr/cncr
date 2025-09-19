namespace DataStructures;

public class DoublyLinkedList
{
    public Node? Head;
    public Node? Tail;
    public int Length;

    public class Node(int value)
    {
        public int Value = value;
        public Node? Next;
        public Node? Prev;
    }

    public DoublyLinkedList(int value)
    {
        Node newNode = new(value);
        Head = newNode;
        Tail = newNode;
        Length = 1;
    }

    public Node? Get(int index)
    {
        if (Head is null || index < 0 || index >= Length) return null;

        Node? temp;

        if (index < Length / 2)
        {
            temp = Head;

            for (int i = 0; i < index; i++)
            {
                temp = temp?.Next;
            }
        }
        else
        {
            temp = Tail;

            for (int i = Length - 1; i > index; i--)
            {
                temp = temp?.Prev;
            }
        }

        return temp;
    }

    public bool Set(int index, int value)
    {
        Node? temp = Get(index);

        if (temp is not null)
        {
            temp.Value = value;
            return true;
        }

        return false;
    }

    public bool Insert(int index, int value)
    {
        if (index < 0 || index > Length) return false;

        if (index == 0)
        {
            Prepend(value);
            return true;
        }

        if (index == Length)
        {
            Append(value);
            return true;
        }

        Node newNode = new(value);
        Node before = Get(index - 1)!;
        Node after = before.Next!;

        newNode.Prev = before;
        newNode.Next = after;
        before.Next = newNode;
        after.Prev = newNode;

        Length++;

        return true;
    }

    public void Append(int value)
    {
        Node newNode = new(value);

        if (Tail is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }

        Length++;
    }

    public void Prepend(int value)
    {
        Node newNode = new(value);

        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }

        Length++;
    }

    public Node? Remove(int index)
    {
        if (index < 0 || index >= Length) return null;

        if (index == 0) return RemoveFirst();
        if (index == Length - 1) return RemoveLast();

        Node temp = Get(index)!;
        Node before = temp.Prev!;
        Node after = temp.Next!;

        temp.Prev = null;
        temp.Next = null;
        before.Next = after;
        after.Prev = before;

        Length--;

        return temp;
    }

    public Node? RemoveFirst()
    {
        if (Head is null) return null;

        Node temp = Head;

        if (Length == 1)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Head = Head.Next;
            Head!.Prev = null;
        }

        temp.Next = null;
        Length--;

        return temp;
    }

    public Node? RemoveLast()
    {
        if (Tail is null) return null;

        Node temp = Tail;

        if (Length == 1)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Tail = Tail.Prev;
            Tail!.Next = null;
        }

        temp.Prev = null;
        Length--;

        return temp;
    }

    public void SwapFirstLast()
    {
        if (Head is null || Tail is null) return;

        (Head.Value, Tail.Value) = (Tail.Value, Head.Value);
    }

    public void Reverse()
    {
        Node? current = Head;
        Node? temp;

        while (current is not null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }

        (Head, Tail) = (Tail, Head);
    }

    public bool IsPalindrome()
    {
        if (Length <= 1) return true;

        Node forwardNode = Head!;
        Node backwardNode = Tail!;

        for (int i = 0; i < Length / 2; i++)
        {
            if (forwardNode.Value != backwardNode.Value) return false;

            forwardNode = forwardNode.Next!;
            backwardNode = backwardNode.Prev!;
        }

        return true;
    }

    public void SwapPairs()
    {
        if (Head is null || Head.Next is null) return;

        Node dummyNode = new(0)
        {
            Next = Head
        };
        Node prevNode = dummyNode;
        Node? current = Head;

        while (current is not null && current.Next is not null)
        {
            Node firstNode = current;
            Node secondNode = current.Next;

            prevNode.Next = secondNode;
            firstNode.Next = secondNode.Next;
            secondNode.Next = firstNode;

            secondNode.Prev = prevNode;
            firstNode.Prev = secondNode;

            if (firstNode.Next is not null)
            {
                firstNode.Next.Prev = firstNode;
            }

            prevNode = firstNode;
            current = firstNode.Next;
        }

        Head = dummyNode.Next;
        if (Head is not null)
        {
            Head.Prev = null;
        }

        var temp = Head;
        while (temp != null && temp.Next != null)
        {
            temp = temp.Next;
        }

        Tail = temp;
    }
}

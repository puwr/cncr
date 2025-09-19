namespace DataStructures;

public class LinkedList
{
    public Node? Head;
    public Node? Tail;
    public int Length;

    public class Node(int value)
    {
        public int Value = value;
        public Node? Next;
    }

    public LinkedList(int value)
    {
        Node newNode = new(value);
        Head = newNode;
        Tail = newNode;
        Length = 1;
    }

    public Node? Get(int index)
    {
        if (Head is null || index < 0 || index >= Length) return null;

        Node? temp = Head;

        for (var i = 0; i < index; i++)
        {
            temp = temp?.Next;
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
        Node temp = Get(index - 1)!;
        newNode.Next = temp.Next;
        temp.Next = newNode;
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
            Head = newNode;
        }

        Length++;
    }

    public Node? Remove(int index)
    {
        if (index < 0 || index >= Length) return null;

        if (index == 0) return RemoveFirst();
        if (index == Length - 1) return RemoveLast();

        Node prev = Get(index - 1)!;
        Node temp = prev.Next!;

        prev.Next = temp.Next;
        temp.Next = null;
        Length--;

        return temp;
    }

    public Node? RemoveFirst()
    {
        if (Head is null) return null;

        Node temp = Head;

        Head = Head.Next;
        temp.Next = null;
        Length--;

        if (Length == 0)
        {
            Tail = null;
        }

        return temp;
    }

    public Node? RemoveLast()
    {
        if (Head is null) return null;

        Node temp = Head;
        Node pre = Head;

        while (temp.Next is not null)
        {
            pre = temp;
            temp = temp.Next;
        }

        Tail = pre;
        Tail.Next = null;
        Length--;

        if (Length == 0)
        {
            Head = null;
            Tail = null;
        }

        return temp;
    }

    public void Reverse()
    {
        if (Head is null) return;

        Node? temp = Head;
        (Tail, Head) = (Head, Tail);

        Node? before = null;

        for (int i = 0; i < Length; i++)
        {
            if (temp is not null)
            {
                Node? after = temp.Next;
                temp.Next = before;
                before = temp;
                temp = after;
            }
        }
    }

    public void ReverseBetween(int startIndex, int endIndex)
    {
        if (Head is null || startIndex >= endIndex) return;

        Node dummyNode = new Node(0);
        dummyNode.Next = Head;
        Node? prevNode = dummyNode;

        for (int i = 0; i < startIndex; i++)
        {
            if (prevNode is null) return;

            prevNode = prevNode.Next;
        }

        if (prevNode is null || prevNode.Next is null) return;

        Node current = prevNode.Next;
        Node? tail = Tail;

        for (int i = 0; i < endIndex - startIndex; i++)
        {
            Node? nodeToMove = current.Next;
            if (nodeToMove is null) break;

            current.Next = nodeToMove.Next;
            nodeToMove.Next = prevNode.Next;
            prevNode.Next = nodeToMove;
        }

        Head = dummyNode.Next;

        if (endIndex >= Length - 1)
        {
            Tail = current;
        }
    }

    public Node? FindMiddleNode()
    {
        if (Head is null) return null;

        return Get(Length / 2);
    }

    public bool HasLoop()
    {
        if (Head is null) return false;

        Node? slow = Head;
        Node? fast = Head;

        while (fast is not null && fast.Next is not null)
        {
            slow = slow.Next!;
            fast = fast.Next.Next;

            if (slow == fast) return true;
        }

        return false;
    }

    public Node? FindKthFromEnd(int k)
    {
        if (Head is null || k <= 0 || k > Length) return null;

        return Get(Length - k);
    }

    public void PartitionList(int x)
    {
        if (Head is null) return;

        Node dummy1 = new(0);
        Node dummy2 = new(0);
        Node prev1 = dummy1;
        Node prev2 = dummy2;
        Node? current = Head;

        while (current is not null)
        {
            if (current.Value < x)
            {
                prev1.Next = current;
                prev1 = current;
            }
            else
            {
                prev2.Next = current;
                prev2 = current;
            }

            current = current.Next;
        }

        prev2.Next = null;
        prev1.Next = dummy2.Next;

        Head = dummy1.Next;
        Tail = (prev2 == dummy2) ? prev1 : prev2;
    }

    public void RemoveDuplicates()
    {
        if (Head is null) return;

        HashSet<int> values = [];
        Node? prev = null;
        Node? current = Head;

        while (current is not null)
        {
            if (!values.Add(current.Value))
            {
                prev!.Next = current.Next;
                Length--;
            }
            else
            {
                prev = current;
            }

            current = current.Next;
        }
    }

    public int BinaryToDecimal()
    {
        int num = 0;
        Node? current = Head;

        while (current is not null)
        {
            num = num * 2 + current.Value;
            current = current.Next;
        }

        return num;
    }
}
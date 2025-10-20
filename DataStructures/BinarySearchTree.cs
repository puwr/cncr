namespace DataStructures;

public class BinarySearchTree
{
    public Node? Root;

    public class Node(int value)
    {
        public int Value = value;
        public Node? Left;
        public Node? Right;
    }

    public bool Insert(int value)
    {
        Node newNode = new(value);

        if (Root is null)
        {
            Root = newNode;
            return true;
        }

        Node temp = Root;

        while (true)
        {
            if (newNode.Value == temp.Value) return false;

            if (newNode.Value < temp.Value)
            {
                if (temp.Left is null)
                {
                    temp.Left = newNode;
                    return true;
                }

                temp = temp.Left;
            }
            else
            {
                if (temp.Right is null)
                {
                    temp.Right = newNode;
                    return true;
                }

                temp = temp.Right;
            }
        }
    }

    public bool Contains(int value)
    {
        Node? temp = Root;

        while (temp is not null)
        {
            if (value < temp.Value)
            {
                temp = temp.Left;
            }
            else if (value > temp.Value)
            {
                temp = temp.Right;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
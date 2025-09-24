namespace DesignPatterns.Structural;

public class Adaptee
{
    public void PrintText()
    {
        Console.WriteLine("Text");
    }
}

interface ITarget
{
    void Print();
}

public class Adapter(Adaptee adaptee) : ITarget
{
    public void Print()
    {
        adaptee.PrintText();
    }
}
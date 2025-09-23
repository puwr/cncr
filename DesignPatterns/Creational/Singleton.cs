namespace DesignPatterns.Creational;

public sealed class Singleton
{
    private static readonly Lazy<Singleton> _instance = new(() => new Singleton());
    public static Singleton Instance => _instance.Value;
    public static bool IsValueCreated => _instance.IsValueCreated;

    private Singleton()
    {
        Console.WriteLine("Instantiating singleton");
    }
}
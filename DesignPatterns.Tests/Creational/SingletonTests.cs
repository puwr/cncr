using DesignPatterns.Creational;

namespace DesignPatterns.Tests.Creational;

public class SingletonTests
{
    [Fact]
    public void Instance_ReturnsSameInstance()
    {
        Singleton.IsValueCreated.Should().BeFalse();

        var instance1 = Singleton.Instance;
        instance1.Should().NotBeNull();

        Singleton.IsValueCreated.Should().BeTrue();

        var instance2 = Singleton.Instance;
        instance2.Should().NotBeNull();

        instance1.Should().BeEquivalentTo(instance2);
    }
}

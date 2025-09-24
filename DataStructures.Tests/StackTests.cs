namespace DataStructures.Tests;

public class StackTests
{
    [Fact]
    public void Stack_InitializesCorrectly()
    {
        var stack = new Stack(1);

        stack.Top.Should().NotBeNull();
        stack.Top.Value.Should().Be(1);
        stack.Height.Should().Be(1);
    }

    [Fact]
    public void Push_PrependsNode()
    {
        var stack = new Stack(1);

        stack.Push(2);

        stack.Top.Should().NotBeNull();
        stack.Top.Value.Should().Be(2);
        stack.Height.Should().Be(2);
    }

    [Fact]
    public void Push_WhenEmptyStack_PrependsNode()
    {
        var stack = new Stack(1);
        stack.Pop();
        
        stack.Push(2);

        stack.Top.Should().NotBeNull();
        stack.Top.Value.Should().Be(2);
        stack.Height.Should().Be(1);
    }

    [Fact]
    public void Pop_RemovesAndReturnsTopNode()
    {
        var stack = new Stack(1);
        stack.Push(2);

        var removedNode = stack.Pop();

        removedNode.Should().NotBeNull();
        removedNode.Value.Should().Be(2);
        removedNode.Next.Should().BeNull();

        stack.Top.Should().NotBeNull();
        stack.Top.Value.Should().Be(1);
        stack.Height.Should().Be(1);
    }

    [Fact]
    public void Pop_WhenEmptyStack_ReturnsNull()
    {
        var stack = new Stack(1);
        stack.Pop();

        var removedNode = stack.Pop();

        removedNode.Should().BeNull();
        stack.Top.Should().BeNull();
    }
}
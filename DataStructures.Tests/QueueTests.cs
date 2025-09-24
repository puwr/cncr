namespace DataStructures.Tests;

public class QueueTests
{
    [Fact]
    public void Queue_InitializesCorrectly()
    {
        var queue = new Queue(1);

        queue.First.Should().NotBeNull();
        queue.First.Value.Should().Be(1);
        queue.Last.Should().NotBeNull();
        queue.Last.Value.Should().Be(1);
        queue.Length.Should().Be(1);
    }

    [Fact]
    public void Enqueue_AppendsNodeAndAssignsLastToIt()
    {
        var queue = new Queue(1);

        queue.Enqueue(2);

        queue.Last.Should().NotBeNull();
        queue.Last.Value.Should().Be(2);
        queue.Length.Should().Be(2);
    }

    [Fact]
    public void Enqueue_WhenEmptyQueue_AppendsNodeAndAssignsFirstAndLastToIt()
    {
        var queue = new Queue(1);
        queue.Dequeue();

        queue.Enqueue(2);

        queue.First.Should().NotBeNull();
        queue.First.Value.Should().Be(2);
        queue.Last.Should().NotBeNull();
        queue.Last.Value.Should().Be(2);
        queue.Length.Should().Be(1);
    }

    [Fact]
    public void Dequeue_RemovesAndReturnsFirstNode()
    {
        var queue = new Queue(1);
        queue.Enqueue(2);

        var node = queue.Dequeue();

        node.Should().NotBeNull();
        node.Value.Should().Be(1);
        queue.Length.Should().Be(1);
    }

    [Fact]
    public void Dequeue_WhenEmptyQueue_ReturnsNull()
    {
        var queue = new Queue(1);
        queue.Dequeue();

        var node = queue.Dequeue();

        node.Should().BeNull();
    }
}
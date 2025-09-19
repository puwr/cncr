namespace DataStructures.Tests;

public class DoublyLinkedListTests
{
    [Fact]
    public void DoublyLinkedList_InitializesCorrectly()
    {
        var dll = new DoublyLinkedList(1);

        dll.Head.Should().NotBeNull();
        dll.Head.Value.Should().Be(1);

        dll.Tail.Should().NotBeNull();
        dll.Tail.Value.Should().Be(1);

        dll.Length.Should().Be(1);
    }

    [Fact]
    public void Get_ReturnsNode()
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);
        dll.Append(3);
        dll.Append(4);

        var node1 = dll.Get(1);
        node1.Should().NotBeNull();
        node1.Value.Should().Be(2);

        var node2 = dll.Get(2);
        node2.Should().NotBeNull();
        node2.Value.Should().Be(3);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void Get_WithInvalidIndex_ReturnsNull(int index)
    {
        var dll = new DoublyLinkedList(1);

        var node = dll.Get(index);

        node.Should().BeNull();
    }

    [Fact]
    public void Set_ReturnsTrue()
    {
        var dll = new DoublyLinkedList(1);

        var result = dll.Set(0, 2);
        result.Should().BeTrue();

        var node = dll.Get(0);
        node.Should().NotBeNull();
        node.Value.Should().Be(2);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void Set_WithInvalidIndex_ReturnsFalse(int index)
    {
        var dll = new DoublyLinkedList(1);

        var result = dll.Set(index, 0);
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void Insert_ReturnsTrue(int index)
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);
        dll.Append(3);

        var result = dll.Insert(index, 0);
        result.Should().BeTrue();
        dll.Length.Should().Be(4);

        var insertedNode = dll.Get(index);
        insertedNode.Should().NotBeNull();
        insertedNode.Value.Should().Be(0);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void Insert_WithInvalidIndex_ReturnsFalse(int index)
    {
        var dll = new DoublyLinkedList(1);

        var result = dll.Insert(index, 0);
        result.Should().BeFalse();
    }

    [Fact]
    public void Append_AppendsNewNodeAndAssignsTailToIt()
    {
        var dll = new DoublyLinkedList(1);

        dll.Append(2);

        dll.Tail.Should().NotBeNull();
        dll.Tail.Value.Should().Be(2);
        dll.Tail.Prev!.Value.Should().Be(1);

        dll.Length.Should().Be(2);
    }

    [Fact]
    public void Append_WhenEmptyList_AppendsNewNodeAndAssignsHeadAndTailToIt()
    {
        var dll = new DoublyLinkedList(1);
        dll.RemoveLast();

        dll.Append(2);

        dll.Head.Should().NotBeNull();
        dll.Head.Value.Should().Be(2);

        dll.Tail.Should().NotBeNull();
        dll.Tail.Value.Should().Be(2);

        dll.Length.Should().Be(1);
    }

    [Fact]
    public void Prepend_PrependsNewNodeAndAssignsHeadToIt()
    {
        var dll = new DoublyLinkedList(1);

        dll.Prepend(2);

        dll.Head.Should().NotBeNull();
        dll.Head.Value.Should().Be(2);
        dll.Head.Next!.Value.Should().Be(1);
        dll.Length.Should().Be(2);
    }

    [Fact]
    public void Prepend_WhenEmptyList_PrependsNewNodeAndAssignsHeadAndTailToIt()
    {
        var dll = new DoublyLinkedList(1);
        dll.RemoveLast();

        dll.Prepend(2);

        dll.Head.Should().NotBeNull();
        dll.Head.Value.Should().Be(2);

        dll.Tail.Should().NotBeNull();
        dll.Tail.Value.Should().Be(2);

        dll.Length.Should().Be(1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void Remove_ReturnsDeletedNode(int index)
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);
        dll.Append(3);

        var removedNode = dll.Remove(index);
        removedNode.Should().NotBeNull();
        removedNode.Prev.Should().BeNull();
        removedNode.Next.Should().BeNull();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void Remove_WithInvalidIndex_ReturnsNull(int index)
    {
        var dll = new DoublyLinkedList(1);

        var removedNode = dll.Remove(index);
        removedNode.Should().BeNull();
    }

    [Fact]
    public void RemoveFirst_RemovesAndReturnsFirstNode()
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);

        var firstRemovedNode = dll.RemoveFirst();

        firstRemovedNode.Should().NotBeNull();
        firstRemovedNode.Value.Should().Be(1);
        firstRemovedNode.Prev.Should().BeNull();
        dll.Length.Should().Be(1);

        var secondRemovedNode = dll.RemoveFirst();

        secondRemovedNode.Should().NotBeNull();
        secondRemovedNode.Value.Should().Be(2);
        secondRemovedNode.Prev.Should().BeNull();
        dll.Length.Should().Be(0);

        dll.Head.Should().BeNull();
        dll.Tail.Should().BeNull();
    }

    [Fact]
    public void RemoveFirst_WhenEmptyList_ReturnsNull()
    {
        var dll = new DoublyLinkedList(1);
        dll.RemoveFirst();

        dll.Head.Should().BeNull();
        dll.Tail.Should().BeNull();
        dll.Length.Should().Be(0);

        var removedNode = dll.RemoveFirst();

        removedNode.Should().BeNull();
    }

    [Fact]
    public void RemoveLast_RemovesAndReturnsLastNode()
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);

        var firstRemovedNode = dll.RemoveLast();

        firstRemovedNode.Should().NotBeNull();
        firstRemovedNode.Value.Should().Be(2);
        firstRemovedNode.Prev.Should().BeNull();
        dll.Length.Should().Be(1);

        var secondRemovedNode = dll.RemoveLast();

        secondRemovedNode.Should().NotBeNull();
        secondRemovedNode.Value.Should().Be(1);
        secondRemovedNode.Prev.Should().BeNull();
        dll.Length.Should().Be(0);

        dll.Head.Should().BeNull();
        dll.Tail.Should().BeNull();
    }

    [Fact]
    public void RemoveLast_WhenEmptyList_ReturnsNull()
    {
        var dll = new DoublyLinkedList(1);
        dll.RemoveLast();

        dll.Head.Should().BeNull();
        dll.Tail.Should().BeNull();
        dll.Length.Should().Be(0);

        var removedNode = dll.RemoveLast();

        removedNode.Should().BeNull();
    }

    [Fact]
    public void SwapFirstLast_SwapsValues()
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);
        dll.Append(3);

        dll.SwapFirstLast();

        dll.Head!.Value.Should().Be(3);
        dll.Tail!.Value.Should().Be(1);
    }

    [Fact]
    public void Reverse_ReversesList()
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);

        dll.Reverse();

        var firstNode = dll.Get(0);
        firstNode.Should().NotBeNull();
        firstNode.Value.Should().Be(2);

        var secondNode = dll.Get(1);
        secondNode.Should().NotBeNull();
        secondNode.Value.Should().Be(1);
    }

    [Fact]
    public void IsPalindrome_WithPalindrome_ReturnsTrue()
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);
        dll.Append(1);

        var result = dll.IsPalindrome();

        result.Should().BeTrue();
    }

    [Fact]
    public void IsPalindrome_WithNoPalindrome_ReturnsFalse()
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);

        var result = dll.IsPalindrome();

        result.Should().BeFalse();
    }

    [Fact]
    public void SwapPairs_SwapsPairs()
    {
        var dll = new DoublyLinkedList(1);
        dll.Append(2);
        dll.Append(3);
        dll.Append(4);

        dll.SwapPairs();

        dll.Head!.Value.Should().Be(2);
        dll.Tail!.Value.Should().Be(3);
    }
}
namespace DataStructures.Tests;

public class LinkedListTests
{
    [Fact]
    public void LinkedList_InitializesCorrectly()
    {
        var linkedList = new LinkedList(1);

        linkedList.Head.Should().NotBeNull();
        linkedList.Head.Value.Should().Be(1);

        linkedList.Tail.Should().NotBeNull();
        linkedList.Tail.Value.Should().Be(1);

        linkedList.Length.Should().Be(1);
    }

    [Fact]
    public void Get_ReturnsNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);

        var node = linkedList.Get(1);

        node.Should().NotBeNull();
        node.Value.Should().Be(2);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void Get_WithInvalidIndex_ReturnsNull(int index)
    {
        var linkedList = new LinkedList(1);

        var node = linkedList.Get(index);

        node.Should().BeNull();
    }

    [Fact]
    public void Set_ReturnsTrue()
    {
        var linkedList = new LinkedList(1);

        var result = linkedList.Set(0, 2);
        result.Should().BeTrue();

        var node = linkedList.Get(0);
        node.Should().NotBeNull();
        node.Value.Should().Be(2);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void Set_WithInvalidIndex_ReturnsFalse(int index)
    {
        var linkedList = new LinkedList(1);

        var result = linkedList.Set(index, 0);
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void Insert_ReturnsTrue(int index)
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);
        linkedList.Append(3);

        var result = linkedList.Insert(index, 0);
        result.Should().BeTrue();
        linkedList.Length.Should().Be(4);

        var insertedNode = linkedList.Get(index);
        insertedNode.Should().NotBeNull();
        insertedNode.Value.Should().Be(0);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void Insert_WithInvalidIndex_ReturnsFalse(int index)
    {
        var linkedList = new LinkedList(1);

        var result = linkedList.Insert(index, 0);
        result.Should().BeFalse();
    }

    [Fact]
    public void Append_AssignsTailToNewNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);

        linkedList.Tail.Should().NotBeNull();
        linkedList.Tail.Value.Should().Be(2);

        linkedList.Length.Should().Be(2);
    }

    [Fact]
    public void Append_WhenEmptyList_AssignsHeadAndTailToNewNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.RemoveLast();

        linkedList.Append(2);

        linkedList.Head.Should().NotBeNull();
        linkedList.Head.Value.Should().Be(2);

        linkedList.Tail.Should().NotBeNull();
        linkedList.Tail.Value.Should().Be(2);

        linkedList.Length.Should().Be(1);
    }

    [Fact]
    public void Prepend_AssignsHeadToNewNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.Prepend(2);

        linkedList.Head.Should().NotBeNull();
        linkedList.Head.Value.Should().Be(2);
        linkedList.Length.Should().Be(2);
    }

    [Fact]
    public void Prepend_WhenEmptyList_AssignsHeadAndTailToNewNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.RemoveLast();

        linkedList.Prepend(2);

        linkedList.Head.Should().NotBeNull();
        linkedList.Head.Value.Should().Be(2);

        linkedList.Tail.Should().NotBeNull();
        linkedList.Tail.Value.Should().Be(2);

        linkedList.Length.Should().Be(1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void Remove_ReturnsDeletedNode(int index)
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);
        linkedList.Append(3);

        var removedNode = linkedList.Remove(index);
        removedNode.Should().NotBeNull();
        removedNode.Next.Should().BeNull();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void Remove_WithInvalidIndex_ReturnsNull(int index)
    {
        var linkedList = new LinkedList(1);

        var removedNode = linkedList.Remove(index);
        removedNode.Should().BeNull();
    }

    [Fact]
    public void RemoveFirst_WhenEmptyList_ReturnsNull()
    {
        var linkedList = new LinkedList(1);
        linkedList.RemoveLast();

        var removedNode = linkedList.RemoveFirst();

        removedNode.Should().BeNull();
        linkedList.Head.Should().BeNull();
        linkedList.Tail.Should().BeNull();
        linkedList.Length.Should().Be(0);
    }

    [Fact]
    public void RemoveFirst_RemovesFirstNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);

        var firstRemovedNode = linkedList.RemoveFirst();

        firstRemovedNode.Should().NotBeNull();
        firstRemovedNode.Value.Should().Be(1);
        linkedList.Length.Should().Be(1);

        var secondRemovedNode = linkedList.RemoveFirst();

        secondRemovedNode.Should().NotBeNull();
        secondRemovedNode.Value.Should().Be(2);
        linkedList.Head.Should().BeNull();
        linkedList.Tail.Should().BeNull();
        linkedList.Length.Should().Be(0);
    }

    [Fact]
    public void RemoveLast_WhenEmptyList_ReturnsNull()
    {
        var linkedList = new LinkedList(1);
        linkedList.RemoveLast();

        var removedNode = linkedList.RemoveLast();

        removedNode.Should().BeNull();
        linkedList.Head.Should().BeNull();
        linkedList.Tail.Should().BeNull();
        linkedList.Length.Should().Be(0);
    }

    [Fact]
    public void RemoveLast_RemovesLastNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);

        var firstRemovedNode = linkedList.RemoveLast();

        firstRemovedNode.Should().NotBeNull();
        firstRemovedNode.Value.Should().Be(2);
        linkedList.Length.Should().Be(1);

        var secondRemovedNode = linkedList.RemoveLast();

        secondRemovedNode.Should().NotBeNull();
        secondRemovedNode.Value.Should().Be(1);
        linkedList.Head.Should().BeNull();
        linkedList.Tail.Should().BeNull();
        linkedList.Length.Should().Be(0);
    }

    [Fact]
    public void Reverse_ReversesList()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);

        linkedList.Reverse();

        var firstNode = linkedList.Get(0);
        firstNode.Should().NotBeNull();
        firstNode.Value.Should().Be(2);

        var secondNode = linkedList.Get(1);
        secondNode.Should().NotBeNull();
        secondNode.Value.Should().Be(1);
    }

    [Fact]
    public void ReverseBetween_ReversesNodes()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);
        linkedList.Append(3);
        linkedList.Append(4);

        linkedList.ReverseBetween(1, 3);

        var secondNode = linkedList.Get(1);
        secondNode.Should().NotBeNull();
        secondNode.Value.Should().Be(4);

        linkedList.Tail.Should().NotBeNull();
        linkedList.Tail.Value.Should().Be(2);
    }

    [Fact]
    public void FindMiddleNode_WhenOddElements_ReturnsMiddleNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);
        linkedList.Append(3);

        var middleNode = linkedList.FindMiddleNode();
        middleNode.Should().NotBeNull();
        middleNode.Value.Should().Be(2);
    }

    [Fact]
    public void FindMiddleNode_WhenEvenElements_ReturnsSecondMiddleNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);
        linkedList.Append(3);
        linkedList.Append(4);

        var middleNode = linkedList.FindMiddleNode();
        middleNode.Should().NotBeNull();
        middleNode.Value.Should().Be(3);
    }

    [Fact]
    public void HasLoop_WithNoLoop_ReturnsFalse()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);
        linkedList.Append(3);

        var result = linkedList.HasLoop();
        result.Should().BeFalse();
    }

    [Fact]
    public void HasLoop_WithLoop_ReturnsTrue()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);
        linkedList.Append(3);
        linkedList.Append(4);

        // Create partial loop
        linkedList.Head!.Next!.Next!.Next = linkedList.Head.Next;

        var result = linkedList.HasLoop();
        result.Should().BeTrue();
    }

    [Fact]
    public void FindKthFromEnd_ReturnsCorrectNode()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);
        linkedList.Append(3);
        linkedList.Append(4);

        var result = linkedList.FindKthFromEnd(4);
        result.Should().NotBeNull();
        result.Value.Should().Be(1);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void FindKthFromEnd_WithInvalidK_ReturnsNull(int k)
    {
        var linkedList = new LinkedList(1);

        var result = linkedList.FindKthFromEnd(k);
        result.Should().BeNull();
    }

    [Fact]
    public void PartitionList_WhenAllNodesSmaller_ReturnsOriginalOrder()
    {
        var linkedList = new LinkedList(3);
        linkedList.Append(2);
        linkedList.Append(1);

        linkedList.PartitionList(5);

        linkedList.Head.Should().NotBeNull();
        linkedList.Head.Value.Should().Be(3);

        linkedList.Tail.Should().NotBeNull();
        linkedList.Tail.Value.Should().Be(1);

        var hasLoopResult = linkedList.HasLoop();
        hasLoopResult.Should().BeFalse();
    }

    [Fact]
    public void PartitionList_WhenAllNodesGreaterOrEqual_ReturnsOriginalOrder()
    {
        var linkedList = new LinkedList(7);
        linkedList.Append(6);
        linkedList.Append(5);

        linkedList.PartitionList(5);

        linkedList.Head.Should().NotBeNull();
        linkedList.Head.Value.Should().Be(7);

        linkedList.Tail.Should().NotBeNull();
        linkedList.Tail.Value.Should().Be(5);

        var hasLoopResult = linkedList.HasLoop();
        hasLoopResult.Should().BeFalse();
    }

    [Fact]
    public void PartitionList_WhenNodesMixed_ReturnsPartitionedOrder()
    {
        var linkedList = new LinkedList(7);
        linkedList.Append(1);
        linkedList.Append(8);
        linkedList.Append(3);

        linkedList.PartitionList(5);

        linkedList.Head.Should().NotBeNull();
        linkedList.Head.Value.Should().Be(1);

        linkedList.Tail.Should().NotBeNull();
        linkedList.Tail.Value.Should().Be(8);

        var hasLoopResult = linkedList.HasLoop();
        hasLoopResult.Should().BeFalse();
    }

    [Fact]
    public void RemoveDuplicates_RemovesDuplicates()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(2);
        linkedList.Append(2);
        linkedList.Append(3);
        linkedList.Append(3);

        linkedList.RemoveDuplicates();

        linkedList.Length.Should().Be(3);
    }

    [Fact]
    public void BinaryToDecimal_Converts1To1()
    {
        var linkedList = new LinkedList(1);

        var num = linkedList.BinaryToDecimal();

        num.Should().Be(1);
    }

    [Fact]
    public void BinaryToDecimal_Converts101To5()
    {
        var linkedList = new LinkedList(1);
        linkedList.Append(0);
        linkedList.Append(1);

        var num = linkedList.BinaryToDecimal();

        num.Should().Be(5);
    }
}
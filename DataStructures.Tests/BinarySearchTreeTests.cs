namespace DataStructures.Tests;

public class BinarySearchTreeTests
{
    [Fact]
    public void Insert_InsertsNewNodeAndReturnsTrue()
    {
        var bst = new BinarySearchTree();
        bst.Insert(2);
        bst.Root.Should().NotBeNull();
        bst.Root.Value.Should().Be(2);

        var insertOneResult = bst.Insert(1);
        insertOneResult.Should().BeTrue();
        bst.Root.Left.Should().NotBeNull();
        bst.Root.Left.Value.Should().Be(1);

        var insertThreeResult = bst.Insert(3);
        insertThreeResult.Should().BeTrue();
        bst.Root.Right.Should().NotBeNull();
        bst.Root.Right.Value.Should().Be(3);

        var insertFourResult = bst.Insert(4);
        insertFourResult.Should().BeTrue();
        bst.Root.Right.Right.Should().NotBeNull();
        bst.Root.Right.Right.Value.Should().Be(4);
    }

    [Fact]
    public void Insert_WhenValueExists_ReturnsFalse()
    {
        var bst = new BinarySearchTree();
        bst.Insert(1);

        var result = bst.Insert(1);

        result.Should().BeFalse();
    }

    [Fact]
    public void Contains_WhenValueExists_ReturnsTrue()
    {
        var bst = new BinarySearchTree();
        bst.Insert(1);
        bst.Insert(3);

        var result = bst.Contains(3);

        result.Should().BeTrue();
    }

    [Fact]
    public void Contains_WhenValueNotExists_ReturnsFalse()
    {
        var bst = new BinarySearchTree();
        bst.Insert(1);
        bst.Insert(3);

        var result = bst.Contains(2);

        result.Should().BeFalse();
    }

    [Fact]
    public void Contains_WhenEmptyTree_ReturnsFalse()
    {
        var bst = new BinarySearchTree();

        var result = bst.Contains(1);

        result.Should().BeFalse();
    }
}
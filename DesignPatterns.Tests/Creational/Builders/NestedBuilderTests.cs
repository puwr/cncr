using DesignPatterns.Creational.Builders;

namespace DesignPatterns.Tests.Creational.Builders;

public class NestedBuilderTests
{
    [Fact]
    public void ShowNestedBuilder_BuildsCorrectObject()
    {
        var builder = new Show.NestedBuilder();

        builder.BuildTitle("Show");
        builder.BuildDescription("Show description");

        var show = builder.Build();

        show.Should().NotBeNull();
        show.Title.Should().Be("Show");
        show.Description.Should().Be("Show description");
    }
}

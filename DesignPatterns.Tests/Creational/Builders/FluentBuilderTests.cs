using DesignPatterns.Creational.Builders;

namespace DesignPatterns.Tests.Creational.Builders;

public class FluentBuilderTests
{
    [Fact]
    public void CartoonFluentBuilder_BuildsCorrectObject()
    {
        var cartoon = new Cartoon.FluentBuilder()
            .SetTitle("Cartoon")
            .SetDescription("Cartoon description")
            .Build();

        cartoon.Should().NotBeNull();
        cartoon.Title.Should().Be("Cartoon");
        cartoon.Description.Should().Be("Cartoon description");
    }
}

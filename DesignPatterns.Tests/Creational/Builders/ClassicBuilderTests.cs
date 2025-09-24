using DesignPatterns.Creational.Builders;

namespace DesignPatterns.Tests.Creational.Builders;

public class ClassicBuilderTests
{
    [Fact]
    public void ClassicBuilder_BuildsCorrectObject()
    {
        var builder = new ClassicBuilder();
        var director = new ClassicDirector(builder);

        director.ConstructMovie();
        var movie = builder.Build();

        movie.Should().NotBeNull();
        movie.Title.Should().Be("Movie");
        movie.Description.Should().Be("Movie description");
    }

    [Fact]
    public void ClassicBuilder_WithNoDirector_BuildsCorrectObject()
    {
        var builder = new ClassicBuilder();
        builder.BuildTitle();
        builder.BuildDescription();

        var movie = builder.Build();

        movie.Should().NotBeNull();
        movie.Title.Should().Be("Movie");
        movie.Description.Should().Be("Movie description");
    }
}

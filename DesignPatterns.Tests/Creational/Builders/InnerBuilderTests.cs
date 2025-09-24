using DesignPatterns.Creational.Builders;

namespace DesignPatterns.Tests.Creational.Builders;

public class InnerBuilderTests
{
    [Fact]
    public void InnerBuilder_BuildsCorrectObjects()
    {
        var book = new Book.InnerBuilder()
            .SetTitle("Book")
            .SetDescription("Book description")
            .SetAuthor(author => author
                .SetFirstName("John")
                .SetLastName("Doe"))
            .Build();

        book.Should().NotBeNull();
        book.Title.Should().Be("Book");
        book.Description.Should().Be("Book description");
        book.Author.Should().NotBeNull();
        book.Author.FirstName.Should().Be("John");
        book.Author.LastName.Should().Be("Doe");
    }
}

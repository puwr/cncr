namespace DesignPatterns.Creational.Builders;

public record Author(string FirstName, string LastName)
{
    public class InnerBuilder
    {
        private string _firstName = string.Empty;
        public string _lastName = string.Empty;

        public InnerBuilder SetFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public InnerBuilder SetLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public Author Build()
        {
            return new Author(FirstName: _firstName, LastName: _lastName);
        }
    }
}

public record Book(string Title, string Description, Author? Author)
{
    public class InnerBuilder
    {
        private string _title = string.Empty;
        private string _description = string.Empty;
        private Author? _author;

        public InnerBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public InnerBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public InnerBuilder SetAuthor(Action<Author.InnerBuilder> buildAuthorAction)
        {
            var authorBuilder = new Author.InnerBuilder();
            buildAuthorAction(authorBuilder);
            _author = authorBuilder.Build();
            return this;
        }

        public Book Build()
        {
            return new Book(Title: _title, Description: _description, Author: _author);
        }
    }
}
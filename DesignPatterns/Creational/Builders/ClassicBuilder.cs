namespace DesignPatterns.Creational.Builders;

public record Movie(string Title, string Description);

public class ClassicDirector(ClassicBuilder builder)
{
    public void ConstructMovie()
    {
        builder.BuildTitle();
        builder.BuildDescription();
    }
}

public class ClassicBuilder
{
    private string _title = string.Empty;
    private string _description = string.Empty;

    public void BuildTitle()
    {
        _title = "Movie";
    }

    public void BuildDescription()
    {
        _description = "Movie description";
    }

    public Movie Build()
    {
        return new Movie(Title: _title, Description: _description);
    }
}
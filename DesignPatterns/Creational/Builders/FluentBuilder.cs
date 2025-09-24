namespace DesignPatterns.Creational.Builders;

public record Cartoon(string Title, string Description)
{
    public class FluentBuilder
    {
        private string _title = string.Empty;
        private string _description = string.Empty;

        public FluentBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public FluentBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public Show Build()
        {
            return new Show(Title: _title, Description: _description);
        }
    }
}

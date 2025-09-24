namespace DesignPatterns.Creational.Builders;

public record Show(string Title, string Description)
{
    public class NestedBuilder
    {
        private string _title = string.Empty;
        private string _description = string.Empty;

        public void BuildTitle(string title)
        {
            _title = title;
        }

        public void BuildDescription(string description)
        {
            _description = description;
        }

        public Show Build()
        {
            return new Show(Title: _title, Description: _description);
        }
    }
}

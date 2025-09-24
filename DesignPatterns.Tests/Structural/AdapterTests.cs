using DesignPatterns.Structural;

namespace DesignPatterns.Tests.Structural;

public class AdapterTests
{
    [Fact]
    public void Print_PrintsCorrectText()
    {
        var adapter = new Adapter(new Adaptee());
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        adapter.Print();
        var text = stringWriter.ToString().Trim();

        text.Should().Be("Text");
    }
}

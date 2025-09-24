using DesignPatterns.Creational.Builders;

namespace DesignPatterns.Tests.Creational.Builders;

public class StepBuilderTests
{
    [Fact]
    public void StepBuilder_BuildsCorrectObject()
    {
        var booking = Booking.StepBuilder.Create()
            .SetFirstName("John")
            .SetLastName("Doe")
            .SetCheckInDate(new DateOnly(2026, 01, 01))
            .Build();

        booking.Should().NotBeNull();
        booking.FirstName.Should().Be("John");
        booking.LastName.Should().Be("Doe");
        booking.CheckInDate.Should().Be(new DateOnly(2026, 01, 01));
    }
}

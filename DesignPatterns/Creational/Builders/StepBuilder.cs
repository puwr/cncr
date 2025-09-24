namespace DesignPatterns.Creational.Builders;

public record Booking(string FirstName, string LastName, DateOnly CheckInDate)
{
    public class StepBuilder : IFirstNameStep, ILastNameStep, ICheckInDateStep
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private DateOnly _checkInDate;

        private StepBuilder() {}

        public static IFirstNameStep Create() => new StepBuilder();

        public ILastNameStep SetFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public ICheckInDateStep SetLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public ICheckInDateStep SetCheckInDate(DateOnly checkInDate)
        {
            _checkInDate = checkInDate;
            return this;
        }
        
        public Booking Build()
        {
            return new Booking(
                FirstName: _firstName,
                LastName: _lastName,
                CheckInDate: _checkInDate);
        }
    }

    public interface IFirstNameStep
    {
        ILastNameStep SetFirstName(string firstName);
    }
    public interface ILastNameStep
    {
        ICheckInDateStep SetLastName(string lastName);
    }
    public interface ICheckInDateStep
    {
        ICheckInDateStep SetCheckInDate(DateOnly checkInDate);
        Booking Build();
    }
}
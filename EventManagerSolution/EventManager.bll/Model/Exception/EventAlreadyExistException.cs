
public class EventAlreadyExistException : Exception
{
    public EventAlreadyExistException() : base("This event already exists"){}
}
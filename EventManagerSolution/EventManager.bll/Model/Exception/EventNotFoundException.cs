namespace EventManager.bll.Model.Exception;

public class EventNotFoundException : System.Exception
{
    public EventNotFoundException() : base("Event not found"){}
}
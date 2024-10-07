namespace EventManager.bll.Model.Exception;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string type) : base(type + " not found"){}
}
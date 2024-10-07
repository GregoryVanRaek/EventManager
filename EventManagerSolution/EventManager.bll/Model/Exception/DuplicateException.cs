namespace EventManager.bll.Model.Exception;

public class DuplicateException : ApplicationException
{
    public DuplicateException(string type) 
        : base("This " + type + " already exists"){}
}
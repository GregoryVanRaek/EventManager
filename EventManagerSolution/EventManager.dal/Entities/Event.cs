namespace EventManager.dal.Entities;

public class Event
{
    public int? Id { get; set; }
    public required string Name { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required EventStatus State { get; set; }
    public string Address_Street { get; set; }
    public string Address_Number { get; set; }
    public string Address_Zip { get; set; }
    public string Address_City { get; set; }
    public string Address_Country { get; set; }
    
    public int? CommentId { get; set; }
    public List<Comment>? Comments { get; set; }
    
    public int? DaysId { get; set; }
    public List<Days>? Days { get; set; }
}

public enum EventStatus
{
    Pending, Confirmed, Passed
}
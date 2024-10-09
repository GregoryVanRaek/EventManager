namespace EventManager.dal.Entities;

public class Participation
{
    public required int Id { get; set; }
    public required ParticipationStateEnum State { get; set; }
    public string? OtherInformation { get; set; }
    
    public int DaysId { get; set; } 
    public Days Days { get; set; }
    
    public string UserId { get; set; }
    public User User { get; set; }
}

public enum ParticipationStateEnum
{
    Pending, Confirmed, Declined
}
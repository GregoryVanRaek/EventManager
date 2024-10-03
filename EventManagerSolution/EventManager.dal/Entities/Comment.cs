namespace EventManager.dal.Entities;

public class Comment
{
    public required int Id { get; set; }
    public required string Message { get; set; }
    public required DateOnly MessageDate { get; set; }
    
    public required int UserId { get; set; }
    public User User { get; set; }
    
    public int EventId { get; set; }
    public required Event Event { get; set; }
}
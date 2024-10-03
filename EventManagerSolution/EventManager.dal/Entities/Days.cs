namespace EventManager.dal.Entities;

public class Days
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly StartDate { get; set; }
    
    public int EventId { get; set; }
    public required Event Event { get; set; }
    
    public int ThemeId { get; set; }
    public required Theme Theme { get; set; }
    
    public List<Participation> Participations { get; set; }
}
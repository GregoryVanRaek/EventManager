using EventManager.dal.Entities;

namespace EventManager.Models;

public class DaysViewModel
{
    public int? Id { get; set; }
    
    public string? Name { get; set; }
    
    public DateOnly? StartDate { get; set; }
    
    public Event? Event { get; set; }
    
    public Theme? Theme { get; set; }
    
    public List<Participation>? Participations { get; set; }
    
}
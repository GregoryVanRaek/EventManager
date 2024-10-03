using EventManager.dal.Entities;

namespace EventManager.Models;

public class EventViewModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public EventStatus State { get; set; }
    
}
using EventManager.dal.Entities;

namespace EventManager.Models;

public class EventViewModel
{
    public int? Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public EventStatus State { get; set; }
    
    public string Address_Street { get; set; }
    
    public string Address_Number { get; set; }
    
    public string Address_Zip { get; set; }
    
    public string Address_City { get; set; }
    
    public string Address_Country { get; set; }
    
    public List<Days> Days { get; set; }
    
}
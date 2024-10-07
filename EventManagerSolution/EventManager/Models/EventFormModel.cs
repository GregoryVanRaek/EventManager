using System.ComponentModel.DataAnnotations;
using EventManager.dal.Entities;

namespace EventManager.Models;

public class EventFormModel
{
    public int? Id { get; set; }
    
    [MinLength(4)]
    [MaxLength(100)]
    public required string Name { get; set; }
    
    public required DateTime StartDate { get; set; }
    
    public required DateTime EndDate { get; set; }

    public required EventStatus State { get; set; } = EventStatus.Pending;
    
    public string Address_Street { get; set; }
    
    public string Address_Number { get; set; }
    
    public string Address_Zip { get; set; }
    
    public string Address_City { get; set; }
    
    public string Address_Country { get; set; }
    
    public List<Days>? Days { get; set; }
}
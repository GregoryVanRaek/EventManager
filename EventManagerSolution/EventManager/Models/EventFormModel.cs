using System.ComponentModel.DataAnnotations;
using EventManager.dal.Entities;

namespace EventManager.Models;

public class EventFormModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MinLength(4)]
    [MaxLength(100)]
    public required string Name { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public required DateTime StartDate { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public required DateTime EndDate { get; set; }

    public required EventStatus State { get; set; } = EventStatus.Pending;
    
    [Required]
    public required AddressFormModel Address { get; set; }
    
    public List<Days>? Days { get; set; }
}
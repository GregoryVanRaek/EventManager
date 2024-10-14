using EventManager.dal.Entities;

namespace EventManager.Models;

public class ParticipationViewModel
{
    public int? Id { get; set; }
    public required ParticipationStateEnum State { get; set; }
    public string? OtherInformation { get; set; }
    public int DaysId { get; set; } 
    public Days Days { get; set; }
    public string UserId { get; set; }
}
﻿namespace EventManager.dal.Entities;

public class Days
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public DateOnly? StartDate { get; set; }
    
    public int? EventId { get; set; }
    public Event? Event { get; set; }
    
    public int? ThemeId { get; set; }
    public Theme? Theme { get; set; }
    
    public List<Participation>? Participations { get; set; }
}
using EventManager.dal.Entities;
using EventManager.Models;

namespace EventManager.Mapper;

public static class EventMapper
{
    public static EventViewModel toViewModel(this Event entity)
    {
        return new EventViewModel
        {
            Id = entity.Id,
            Name = entity.Name,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            State = entity.State
        };
    }
}
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

    public static Event toEntity(this EventFormModel model)
    {
        return new Event
        {
            Id = model.Id,
            Name = model.Name,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            State = model.State,
            Address = model.Address.toEntity(),
            Days = new List<Days>()
        };
    }
    
}

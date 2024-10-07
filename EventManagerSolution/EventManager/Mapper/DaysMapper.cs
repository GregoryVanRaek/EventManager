using EventManager.dal.Entities;
using EventManager.Models;

namespace EventManager.Mapper;

public static class DaysMapper
{
    public static DaysViewModel toViewModel(this Days entity)
    {
        return new DaysViewModel
        {
            Id = entity.Id,
            Name = entity.Name,
            StartDate = entity.StartDate,
            Event = entity.Event,
            Theme = entity.Theme,
            Participations = entity.Participations
        };
    }
    
    public static DaysFormModel toFormModel(this Days entity)
    {
        return new DaysFormModel
        {
            Id = entity.Id,
            Name = entity.Name,
            StartDate = entity.StartDate,
            Event = entity.Event,
            Theme = entity.Theme,
            Participations = entity.Participations
        };
    }

    public static Days toEntity(this DaysFormModel model)
    {
        return new Days
        {
            Id = model.Id,
            Name = model.Name,
            StartDate = model.StartDate,
            EventId = model.EventId,
            Event = model.Event,
            Theme = model.Theme,
            Participations = model.Participations
        };
    }
}
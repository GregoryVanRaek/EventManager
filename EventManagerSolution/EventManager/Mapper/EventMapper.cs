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
            State = entity.State,
            Address_Street = entity.Address_Street,
            Address_Number = entity.Address_Number,
            Address_Zip = entity.Address_Zip,
            Address_City = entity.Address_City,
            Address_Country = entity.Address_Country,
        };
    }
    
    public static EventFormModel toFormModel(this Event entity)
    {
        return new EventFormModel
        {
            Id = entity.Id,
            Name = entity.Name,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            State = entity.State,
            Address_Street = entity.Address_Street,
            Address_Number = entity.Address_Number,
            Address_Zip = entity.Address_Zip,
            Address_City = entity.Address_City,
            Address_Country = entity.Address_Country,
            Days = entity.Days
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
            Address_Street = model.Address_Street,
            Address_Number = model.Address_Number,
            Address_Zip = model.Address_Zip,
            Address_City = model.Address_City,
            Address_Country = model.Address_Country,
            Days = new List<Days>()
        };
    }
    
}

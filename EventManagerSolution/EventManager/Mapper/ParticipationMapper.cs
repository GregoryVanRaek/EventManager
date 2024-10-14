using EventManager.dal.Entities;
using EventManager.Models;

namespace EventManager.Mapper;

public static class ParticipationMapper
{
    public static ParticipationFormModel toFormModel(this Participation model)
    {
        return new ParticipationFormModel
        {
            Id = model.Id,
            State = model.State,
            OtherInformation = model.OtherInformation,
            DaysId = model.DaysId,
            UserId = model.UserId,
        };
    }

    public static Participation toEntity(this ParticipationFormModel model)
    {
        return new Participation
        {
            State = model.State,
            OtherInformation = model.OtherInformation,
            DaysId = model.DaysId,
            UserId = model.UserId,
        };
    }
    
    public static ParticipationViewModel toViewModel(this Participation model)
    {
        return new ParticipationViewModel
        {
            Id = model.Id,
            State = model.State,
            OtherInformation = model.OtherInformation,
            DaysId = model.DaysId,
            Days = model.Days,
            UserId = model.UserId,
        };
    }
}
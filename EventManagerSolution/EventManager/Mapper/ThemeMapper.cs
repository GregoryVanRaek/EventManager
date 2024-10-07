using EventManager.dal.Entities;
using EventManager.Models;

namespace EventManager.Mapper;

public static class ThemeMapper
{
    public static ThemeViewModel toViewModel(this Theme entity)
    {
        return new ThemeViewModel
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
    
    public static Theme toEntity(this ThemeFormModel model)
    {
        return new Theme
        {
            Id = model.Id,
            Name = model.Name,
        };
    }
    
    public static ThemeFormModel toFormModel(this Theme entity)
    {
        return new ThemeFormModel
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
    
}
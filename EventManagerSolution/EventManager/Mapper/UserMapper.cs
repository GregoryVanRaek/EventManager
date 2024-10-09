using EventManager.dal.Entities;
using EventManager.Models;

namespace EventManager.Mapper;

public static class UserMapper
{
    public static UserViewModel toViewModel(this User entity)
    {
        return new UserViewModel
        {
            LastName = entity.LastName,
            FirstName = entity.FirstName,
            Email = entity.Email,
        };
    }
    
    public static User toEntity(this UserFormModel entity)
    {
        return new User
        {
            Id = "",
            LastName = entity.LastName,
            FirstName = entity.FirstName,
            Email = entity.Email,
        };
    }
    
}
using EventManager.dal.Entities;
using EventManager.Models;

namespace EventManager.Mapper;

public static class UserMapper
{
    public static UserViewModel toViewModel(this User entity)
    {
        return new UserViewModel
        {
            Id = entity.Id,
            LastName = entity.LastName,
            FirstName = entity.FirstName,
            Email = entity.Email,
            Address_Street = entity.Address_Street,
            Address_Number = entity.Address_Number,
            Address_Zip = entity.Address_Zip,
            Address_City = entity.Address_City,
            Address_Country = entity.Address_Country,
            IsAdmin = entity.IsAdmin,
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
    
    public static User toEntity(this UserViewModel entity)
    {
        return new User
        {
            Id = entity.Id,
            LastName = entity.LastName,
            FirstName = entity.FirstName,
            Email = entity.Email,
            Address_Street = entity.Address_Street,
            Address_Number = entity.Address_Number,
            Address_Zip = entity.Address_Zip,
            Address_City = entity.Address_City,
            Address_Country = entity.Address_Country,
            IsAdmin = entity.IsAdmin,
        };
    }
    
}
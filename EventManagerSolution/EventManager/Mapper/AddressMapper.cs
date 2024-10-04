﻿using EventManager.dal.Entities;
using EventManager.Models;

namespace EventManager.Mapper;

public static class AddressMapper
{
    public static Address toEntity(this AddressFormModel entity)
    {
        return new Address
        {
            Id = entity.Id,
            Street = entity.Street,
            Number = entity.Number,
            Zip = entity.Zip,
            City = entity.City,
            Country = entity.Country,
            Continent = entity.Continent,
            UserId = null
        };
    }
    public static AddressFormModel? toFormModel(this Address? entity)
    {
        if (entity == null) 
            return null;
        
        return new AddressFormModel
        {
            Id = entity.Id,
            Street = entity.Street,
            Number = entity.Number,
            Zip = entity.Zip,
            City = entity.City,
            Country = entity.Country,
            Continent = entity.Continent,
            UserId = entity.UserId
        };
    }
}
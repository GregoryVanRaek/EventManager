﻿using EventManager.dal.Database;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.dal.Repositories;

public class UserRepository(DbContext_EventManager context) : IUserRepository
{
    private readonly DbContext_EventManager _context = context;

    public List<User> GetAll()
    {
        return _context.User.ToList();
    }

    public User? GetOneById(int id)
    {
        throw new NotImplementedException();
    }

    public User Create(User entity)
    {
        throw new NotImplementedException();
    }

    public User Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }
}
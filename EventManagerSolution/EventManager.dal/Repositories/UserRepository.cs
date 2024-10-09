using EventManager.dal.Database;
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
    
    public User? GetByEmail(string email)
    {
        return _context.User.SingleOrDefault(u => u.Email == email);
    }

    public User Create(User entity)
    {
        var insert = _context.User.Add(entity).Entity;
        _context.SaveChanges();
        
        return insert;
    }

    public User Update(User entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(User entity)
    {
        throw new NotImplementedException();
    }
}
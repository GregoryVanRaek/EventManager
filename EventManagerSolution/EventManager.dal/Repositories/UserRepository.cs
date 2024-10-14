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

    public User? GetOneById(string id)
    {
        return _context.User.SingleOrDefault(u => u.Id == id);
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
        var entityToUpdate = _context.User.FirstOrDefault(d => d.Id == entity.Id);
        
        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        
        _context.SaveChanges();

        return entityToUpdate;
    }

    public bool Delete(User entity)
    {
        User? toDelete = _context.User.FirstOrDefault(d => d.Id == entity.Id);

        if (toDelete != null)
        {
            _context.User.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}
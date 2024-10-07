using EventManager.dal.Database;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManager.dal.Repositories;

public class DaysRepository(DbContext_EventManager context) : IDaysRepository
{
    private readonly DbContext_EventManager _context = context;
    
    public List<Days> GetAll()
    {
        return _context.Days.Include(days => days.Event)
                            .ToList();
    }

    public Days? GetOneById(int id)
    {
        return _context.Days.FirstOrDefault(d => d.Id == id);
    }

    public Days Create(Days entity)
    {
        var insert = _context.Days.Add(entity).Entity;
        _context.SaveChanges();
        
        return insert;
    }

    public Days Update(Days entity)
    {
        var entityToUpdate = _context.Days.FirstOrDefault(d => d.Id == entity.Id);
        
        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        
        _context.SaveChanges();

        return entityToUpdate;
    }

    public bool Delete(Days entity)
    {
        var toDelete = _context.Days.FirstOrDefault(d => d.Id == entity.Id);

        if (toDelete != null)
        {
            _context.Days.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}
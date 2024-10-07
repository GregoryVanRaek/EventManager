using EventManager.dal.Database;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManager.dal.Repositories;

public class EventRepository(DbContext_EventManager context) : IEventRepository
{
    private readonly DbContext_EventManager _context = context;
    
    public List<Event> GetAll()
    {
        return _context.Event.Include(e => e.Days)
                             .ToList();
    }

    public Event? GetOneById(int key)
    {
        return _context.Event.Include(e => e.Days)
                             .FirstOrDefault(x => x.Id == key);
    }

    public Event? GetOneByName(string eventName)
    {
        return _context.Event.Include(e => e.Days)
                             .FirstOrDefault(x => x.Name.Contains(eventName));
    }

    public Event Create(Event entity)
    {
        var insert = _context.Event.Add(entity).Entity;
        _context.SaveChanges();
        
        return insert;
    }

    public Event Update(Event entity)
    {
        var entityToUpdate = _context.Event.FirstOrDefault(x => x.Id == entity.Id);
        
        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        
        _context.SaveChanges();

        return entityToUpdate;
    }

    public bool Delete(Event entity)
    {
        var toDelete = _context.Event.FirstOrDefault(x => x.Id == entity.Id);

        if (toDelete != null)
        {
            _context.Event.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}
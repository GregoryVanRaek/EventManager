using EventManager.dal.Database;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.dal.Repositories;

public class EventRepository(DbContext_EventManager context) : IEventRepository
{
    private readonly DbContext_EventManager _context = context;
    
    public List<Event> GetAll()
    {
        return _context.Event.ToList();
    }

    public Event? GetOneById(int key)
    {
        return _context.Event.FirstOrDefault(x => x.Id == key);
    }

    public Event? GetOneByName(string eventName)
    {
        return _context.Event.FirstOrDefault(x => x.Name == eventName);
    }

    public Event Create(Event entity)
    {
        var insert = _context.Event.Add(entity).Entity;
        _context.SaveChanges();
        
        return insert;
    }

    public Event Update(Event entity)
    {
        throw new NotImplementedException();
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
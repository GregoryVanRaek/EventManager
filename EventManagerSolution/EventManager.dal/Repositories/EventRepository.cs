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
        return _context.Event.Add(entity).Entity;
    }

    public Event Update(Event entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Event entity)
    {
        throw new NotImplementedException();
    }
}
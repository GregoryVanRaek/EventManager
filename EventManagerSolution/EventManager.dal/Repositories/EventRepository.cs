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
        return _context.Event.Include(e => e.Address)
                             .ToList();
    }

    public Event? GetOneById(int key)
    {
        return _context.Event.Include(e => e.Address)
                             .FirstOrDefault(x => x.Id == key);
    }

    public Event? GetOneByName(string eventName)
    {
        return _context.Event.FirstOrDefault(x => x.Name.Contains(eventName));
    }

    public Event Create(Event entity)
    {
        var insert = _context.Event.Add(entity).Entity;
        _context.SaveChanges();
        
        return insert;
    }

    public Event Update(Event entity)
    {
        var entityToUpdate = _context.Event.Include(e => e.Address)
                                                 .FirstOrDefault(x => x.Id == entity.Id);
        /*
        entityToUpdate.Name = entity.Name;
        entityToUpdate.StartDate = entity.StartDate;
        entityToUpdate.EndDate = entity.EndDate;
        entityToUpdate.Address.Street = entity.Address.Street;
        entityToUpdate.Address.Number = entity.Address.Number;
        entityToUpdate.Address.Zip = entity.Address.Zip;
        entityToUpdate.Address.City = entity.Address.City;
        entityToUpdate.Address.Country = entity.Address.Country;
        entityToUpdate.Address.Continent = entity.Address.Continent;
        */
        
        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        _context.Entry(entityToUpdate.Address).CurrentValues.SetValues(entity.Address); // problème id adresse non passé donc résultat null donc formulaire non validé
        
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
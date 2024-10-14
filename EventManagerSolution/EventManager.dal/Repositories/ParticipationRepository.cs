using EventManager.dal.Database;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManager.dal.Repositories;

public class ParticipationRepository(DbContext_EventManager _context) : IParticipationRepository
{
    public List<Participation> GetAll()
    {
        return _context.Participation.Include(x => x.Days)
                                     .Include(x => x.User)
                                     .ToList();
    }

    public Participation? GetOneById(int id)
    {
        return _context.Participation.FirstOrDefault(t => t.Id == id);
    }
    public Participation Create(Participation entity)
    {
        var insert = _context.Participation.Add(entity).Entity;
        _context.SaveChanges();
        
        return insert;
    }

    public Participation Update(Participation entity)
    {
        var entityToUpdate = _context.Participation.FirstOrDefault(t => t.Id == entity.Id);
        
        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        
        _context.SaveChanges();

        return entityToUpdate;
    }

    public bool Delete(Participation entity)
    {
        var toDelete = _context.Participation.FirstOrDefault(t => t.Id == entity.Id);

        if (toDelete != null)
        {
            _context.Participation.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}
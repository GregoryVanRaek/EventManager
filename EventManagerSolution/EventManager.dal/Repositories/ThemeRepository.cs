using EventManager.dal.Database;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.dal.Repositories;

public class ThemeRepository(DbContext_EventManager context) : IThemeRepository
{
    private readonly DbContext_EventManager _context = context;
    
    public List<Theme> GetAll()
    {
        return _context.Theme.ToList();
    }

    public Theme? GetOneById(int id)
    {
        return _context.Theme.FirstOrDefault(t => t.Id == id);
    }
    
    public Theme? GetOneByName(string eventName)
    {
        return _context.Theme.FirstOrDefault(t => t.Name.Contains(eventName));
    }

    public Theme Create(Theme entity)
    {
        var insert = _context.Theme.Add(entity).Entity;
        _context.SaveChanges();
        
        return insert;
    }

    public Theme Update(Theme entity)
    {
        var entityToUpdate = _context.Theme.FirstOrDefault(t => t.Id == entity.Id);
        
        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        
        _context.SaveChanges();

        return entityToUpdate;
    }

    public bool Delete(Theme entity)
    {
        var toDelete = _context.Theme.FirstOrDefault(t => t.Id == entity.Id);

        if (toDelete != null)
        {
            _context.Theme.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}
using EventManager.bll.Model.Exception;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.bll.Service;

public class EventService(IEventRepository repo) : IEventService
{
    private readonly IEventRepository _repository = repo;
    
    public List<Event> GetAll()
    {
        return _repository.GetAll();
    }

    public Event GetOneById(int id)
    {
        Event? result = _repository.GetOneById(id);
        
        if(result is null)
            throw new EventNotFoundException();

        return result;
    }
    
    public Event? GetOneByName(string eventName)
    {
        Event? result = _repository.GetOneByName(eventName);
        
        if(result is null)
            throw new EventNotFoundException();

        return result;
    }

    public Event Create(Event entity)
    {
        if (!CheckIfEventExist(entity))
            return _repository.Create(entity);
        
        throw new EventAlreadyExistException();
    }

    public Event Update(Event entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Event entity)
    {
        if (CheckIfEventExist(entity))
            return _repository.Delete(entity);
        
        throw new EventNotFoundException();
    }
    
    // Fonctions internes
    private bool CheckIfEventExist(Event entity)
    {
        Event? e = _repository.GetOneByName(entity.Name);
        
        if(e != null)
            return e.StartDate == entity.StartDate;

        return false;
    }
}
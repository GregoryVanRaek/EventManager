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

    public Event GetOneById(int key)
    {
        throw new NotImplementedException();
    }

    public Event Create(Event entity)
    {
        throw new NotImplementedException();
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
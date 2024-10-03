using EventManager.dal.Entities;

namespace EventManager.bll.Service.Interfaces;

public interface IEventService : IService<int, Event>
{
    public Event? GetOneByName(string eventName);
}
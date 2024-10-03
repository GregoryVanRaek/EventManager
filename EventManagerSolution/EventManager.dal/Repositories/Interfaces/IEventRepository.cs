using EventManager.dal.Entities;

namespace EventManager.dal.Repositories.Interfaces;

public interface IEventRepository :IRepository<int, Event>
{
}
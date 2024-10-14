using EventManager.dal.Entities;

namespace EventManager.bll.Service.Interfaces;

public interface IUserService : IService<string, User>
{
    public User? GetByEmail(string email);
}
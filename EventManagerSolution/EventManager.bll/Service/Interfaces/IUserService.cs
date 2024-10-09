using EventManager.dal.Entities;

namespace EventManager.bll.Service.Interfaces;

public interface IUserService : IService<int, User>
{
    public User Create(User entity, string password);
    public User? GetByEmail(string email);
}
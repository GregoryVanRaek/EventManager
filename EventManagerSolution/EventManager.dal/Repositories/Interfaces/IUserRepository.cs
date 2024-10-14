using EventManager.dal.Entities;

namespace EventManager.dal.Repositories.Interfaces;

public interface IUserRepository : IRepository<string, User>
{
    public User? GetByEmail(string email);
}
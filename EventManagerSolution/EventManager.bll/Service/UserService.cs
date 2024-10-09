using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.bll.Service;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    
    public List<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    public User GetOneById(int key)
    {
        throw new NotImplementedException();
    }

    public User? GetByEmail(string email)
    {
        return _userRepository.GetByEmail(email);
    }

    public User Create(User entity)
    {
        _userRepository.Create(entity);
        return entity;
    }

    public User Update(User entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(User entity)
    {
        throw new NotImplementedException();
    }
}
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

    public User Create(User entity)
    {
        throw new NotImplementedException();
    }

    public User Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }
}
using EventManager.bll.Model.Exception;
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

    public User GetOneById(string key)
    {
        User? result = _userRepository.GetOneById(key);
        
        if(result is null)
            throw new NotFoundException("user");

        return result;
    }

    public User? GetByEmail(string email)
    {
        User? result = _userRepository.GetByEmail(email);
        
        if(result is null)
            return null;
        
        return result;
    }

    public User Create(User entity)
    {
        if (!CheckIfUserExist(entity))
            return _userRepository.Create(entity);
        
        throw new DuplicateException("user");
    }

    public User Update(User entity)
    {
        if (CheckIfUserExist(entity))
            return _userRepository.Update(entity);
        
        throw new NotFoundException("user");
    }

    public bool Delete(User entity)
    {
        if (CheckIfUserExist(entity))
            return _userRepository.Delete(entity);
        
        throw new NotFoundException("user");
    }
    
    private bool CheckIfUserExist(User entity)
    {
        return _userRepository.GetOneById(entity.Id) != null;
    }
}
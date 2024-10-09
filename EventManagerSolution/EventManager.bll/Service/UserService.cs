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
        throw new NotImplementedException();
    }

    public User Create(User entity, string password)
    {
        PasswordService.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        User newUser = new User
        {
            Id = Ulid.NewUlid().ToString(),
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        
        _userRepository.Create(newUser);
        
        return newUser;
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
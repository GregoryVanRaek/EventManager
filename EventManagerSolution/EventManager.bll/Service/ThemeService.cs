using EventManager.bll.Model.Exception;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.bll.Service;

public class ThemeService(IThemeRepository repo) : IThemeService
{
    private readonly IThemeRepository _repository = repo;
    
    public List<Theme> GetAll()
    {
        return _repository.GetAll();
    }

    public Theme? GetOneById(int id)
    {
        Theme? result = _repository.GetOneById(id);
        
        if(result is null)
            throw new NotFoundException("theme");

        return result;
    }
    
    public Theme? GetOneByName(string themeName)
    {
        Theme? result = _repository.GetOneByName(themeName);
        
        if(result is null)
            throw new NotFoundException("theme");

        return result;
    }

    public Theme Create(Theme entity)
    {
        if (!CheckIfThemeExist(entity))
            return _repository.Create(entity);
        
        throw new DuplicateException("theme");
    }

    public Theme Update(Theme entity)
    {
        if (CheckIfThemeExist(entity))
            return _repository.Update(entity);
        
        throw new NotFoundException("theme");
    }

    public bool Delete(Theme entity)
    {
        if (CheckIfThemeExist(entity))
            return _repository.Delete(entity);
        
        throw new NotFoundException("theme");
    }
    
    private bool CheckIfThemeExist(Theme entity)
    {
        return _repository.GetOneById(entity.Id ?? 0) != null;
    }
}
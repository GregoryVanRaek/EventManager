using EventManager.bll.Model.Exception;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.bll.Service;

public class DaysService(IDaysRepository repo) : IDaysService
{
    private readonly IDaysRepository _repository = repo;
    
    public List<Days> GetAll()
    {
        return _repository.GetAll();
    }

    public Days GetOneById(int id)
    {
        Days? result = _repository.GetOneById(id);
        
        if(result is null)
            throw new NotFoundException("days");

        return result;
    }

    public Days Create(Days entity)
    {
        if (!CheckIfDayExist(entity))
            return _repository.Create(entity);
        
        throw new DuplicateException("days");
    }

    public Days Update(Days entity)
    {
        if (CheckIfDayExist(entity))
            return _repository.Update(entity);
        
        throw new NotFoundException("days");
    }

    public bool Delete(Days entity)
    {
        if (CheckIfDayExist(entity))
            return _repository.Delete(entity);
        
        throw new NotFoundException("days");
    }
    
    private bool CheckIfDayExist(Days entity)
    {
        return _repository.GetOneById(entity.Id ?? 0) != null;
    }
}
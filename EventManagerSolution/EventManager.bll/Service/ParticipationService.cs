using EventManager.bll.Model.Exception;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.bll.Service;

public class ParticipationService(IParticipationRepository _repository) : IParticipationService
{
    public List<Participation> GetAll()
    {
        return _repository.GetAll();
    }

    public Participation? GetOneById(int id)
    {
        Participation? result = _repository.GetOneById(id);
        
        if(result is null)
            throw new NotFoundException("Participation");

        return result;
    }

    public Participation Create(Participation entity)
    {
        if (!ParticipationExist(entity))
            return _repository.Create(entity);
        
        throw new DuplicateException("Participation");
    }

    public Participation Update(Participation entity)
    {
        if (ParticipationExist(entity))
            return _repository.Update(entity);
        
        throw new NotFoundException("Participation");
    }

    public bool Delete(Participation entity)
    {
        if (ParticipationExist(entity))
            return _repository.Delete(entity);
        
        throw new NotFoundException("Participation");
    }
    
    private bool ParticipationExist(Participation entity)
    {
        return _repository.GetOneById(entity.Id ?? 0) != null;
    }
}
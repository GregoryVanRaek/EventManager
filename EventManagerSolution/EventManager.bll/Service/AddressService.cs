using EventManager.bll.Model.Exception;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.bll.Service;

public class AddressService(IAddressRepository repo) : IAddressService
{
    private readonly IAddressRepository _repository = repo;
    
    public List<Address> GetAll()
    {
        return _repository.GetAll();
    }

    public Address GetOneById(int key)
    {
        throw new NotImplementedException();
    }

    public Address Create(Address entity)
    {
        if (!CheckIfAddressExist(entity))
            return _repository.Create(entity);

        throw new AddressAlreadyExistException();
    }

    public Address Update(Address entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Address entity)
    {
        throw new NotImplementedException();
    }
    
    private bool CheckIfAddressExist(Address entity)
    {
        return (_repository.GetAll()
                    .FirstOrDefault(a
                        => a.Street == entity.Street
                           && a.Number == entity.Number
                           && a.Zip == entity.Zip
                           && a.City == entity.City
                           && a.Country == entity.Country
                           && a.Continent == entity.Continent
                    )
                != null);
    }
}
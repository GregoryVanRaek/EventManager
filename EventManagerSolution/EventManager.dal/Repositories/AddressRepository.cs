using EventManager.dal.Database;
using EventManager.dal.Entities;
using EventManager.dal.Repositories.Interfaces;

namespace EventManager.dal.Repositories;

public class AddressRepository(DbContext_EventManager context) : IAddressRepository
{
    private readonly DbContext_EventManager _context = context;
    
    public List<Address> GetAll()
    {
        return _context.Address.ToList();
    }

    public Address? GetOneById(int key)
    {
        throw new NotImplementedException();
    }

    public Address Create(Address entity)
    {
        var insert = _context.Address.Add(entity).Entity;
        _context.SaveChanges();
        Console.WriteLine(insert);
        
        return insert;
    }

    public Address Update(Address entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Address entity)
    {
        throw new NotImplementedException();
    }
}
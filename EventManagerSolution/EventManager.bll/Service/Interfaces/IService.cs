namespace EventManager.bll.Service.Interfaces;

public interface IService<Key, T>
{
    public List<T> GetAll();
    public T GetOneById(Key key);
    public T Create(T entity);
    public T Update(T entity);
    public bool Delete(T entity);
}
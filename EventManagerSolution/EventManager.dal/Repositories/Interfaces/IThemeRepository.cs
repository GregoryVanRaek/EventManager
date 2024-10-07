using EventManager.dal.Entities;

namespace EventManager.dal.Repositories.Interfaces;

public interface IThemeRepository : IRepository<int, Theme>
{
    public Theme? GetOneByName(string themeName);
}
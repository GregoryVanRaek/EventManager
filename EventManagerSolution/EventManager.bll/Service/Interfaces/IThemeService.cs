using EventManager.dal.Entities;

namespace EventManager.bll.Service.Interfaces;

public interface IThemeService : IService<int, Theme>
{
    Theme? GetOneByName(string themeName);
}
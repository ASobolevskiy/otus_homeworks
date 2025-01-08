using DI;

namespace SaveSystem
{
    public interface ISaveLoader
    { 
        void SaveData(ServiceLocator serviceLocator, IGameRepository gameRepository);
        void LoadData(ServiceLocator serviceLocator, IGameRepository gameRepository);
    }
}
using DI;

namespace SaveSystem
{
    public abstract class SaveLoader<TSaveData, TService> : ISaveLoader where TService : class
    {
        void ISaveLoader.SaveData(ServiceLocator serviceLocator, IGameRepository gameRepository)
        {
            var service = serviceLocator.GetService<TService>();
            var data = ConvertToSaveData(service);
            gameRepository.SetData(data);
        }
        
        void ISaveLoader.LoadData(ServiceLocator serviceLocator, IGameRepository gameRepository)
        {
            if (!gameRepository.TryGetData(out TSaveData data))
            {
                return;
            }

            var service = serviceLocator.GetService<TService>();
            SetupData(service, data);
        }
        
        protected abstract TSaveData ConvertToSaveData(TService service);
        protected abstract void SetupData(TService service, TSaveData data);
    }
}
using DI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveSystem
{
    public class SaveLoadManager : MonoBehaviour
    {
        private ISaveLoader[] _saveLoaders;
        private GameRepository _gameRepository;
        private ServiceLocator serviceLocator;
        
        [Inject]
        public void Construct(GameRepository gameRepository, ISaveLoader[] saveLoaders)
        {
            serviceLocator = FindObjectOfType<ServiceLocator>();
            _gameRepository = gameRepository;
            _saveLoaders = saveLoaders;
        }

        [Button]
        public void SaveGame()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveData(serviceLocator, _gameRepository);
            }
            
            _gameRepository.SaveState();
        }

        [Button]
        public void LoadGame()
        {
            _gameRepository.LoadState();
            
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadData(serviceLocator, _gameRepository);
            }
        }
    }
}
using System.Collections.Generic;
using DI;
using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveSystem
{
    public class SaveLoadManager : MonoBehaviour
    {
        private ISaveLoader[] _saveLoaders;
        
        [Inject]
        public void Construct(ISaveLoader[] saveLoaders)
        {
            _saveLoaders = saveLoaders;
        }

        [Button]
        public void SaveGame()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveData();
            }
        }

        [Button]
        public void LoadGame()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadData();
            }
        }
    }
}
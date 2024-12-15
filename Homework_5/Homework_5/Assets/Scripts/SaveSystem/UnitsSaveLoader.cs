using DI;
using GameEngine;

namespace SaveSystem
{
    public class UnitsSaveLoader : ISaveLoader
    {
        private UnitManager _unitManager;

        [Inject]
        public void Construct(UnitManager unitManager)
        {
            _unitManager = unitManager;
        }
        
        void ISaveLoader.SaveData()
        {
        }

        void ISaveLoader.LoadData()
        {
        }
    }
}
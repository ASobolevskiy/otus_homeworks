using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Homework
{
    public class HeroExperiencePresenter : IExperiencePresenter
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private readonly PlayerLevel _playerLevelData;

        public int CurrentLevel { get; set; }
        public int CurrentExperience { get; set; }
        public int RequiredExperience { get; set; }
        
        public bool CanLevelUp { get; set; }

        public HeroExperiencePresenter(HeroExperience heroExperienceData)
        {
            _playerLevelData = heroExperienceData.PlayerLevelData;
            CurrentLevel = _playerLevelData.CurrentLevel;
            CurrentExperience = _playerLevelData.CurrentExperience;
            RequiredExperience = _playerLevelData.RequiredExperience;
            CanLevelUp = _playerLevelData.CanLevelUp();
        }

        public void LevelUp()
        {
            _playerLevelData.LevelUp();
        }
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
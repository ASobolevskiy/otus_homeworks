using System;
using System.Collections.Generic;
using UnityEngine;

namespace Homework
{
    [Serializable]
    public sealed class PlayerLevel
    {
        public event Action OnLevelUp;
        public event Action<int> OnExperienceChanged;
        
        [field: SerializeField]
        public int CurrentLevel { get; private set; } = 1;

        [field: SerializeField]
        public int CurrentExperience { get; private set; }
        
        public int RequiredExperience => 100 * (CurrentLevel + 1);


        public void AddExperience(int range)
        {
            var xp = Math.Min(this.CurrentExperience + range, this.RequiredExperience);
            this.CurrentExperience = xp;
            this.OnExperienceChanged?.Invoke(xp);
        }

        
        public void LevelUp()
        {
            if (this.CanLevelUp())
            {
                this.CurrentExperience = 0;
                this.CurrentLevel++;
                this.OnLevelUp?.Invoke();
            }
        }

        public bool CanLevelUp()
        {
            return this.CurrentExperience == this.RequiredExperience;
        }
    }
}
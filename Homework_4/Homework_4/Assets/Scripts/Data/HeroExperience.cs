using System;
using EasyButtons;
using Unity.VisualScripting;
using UnityEngine;

namespace Homework
{
    [CreateAssetMenu(fileName = "HeroExperience", menuName = "Data/Experience Data/New Hero Experience")]
    public class HeroExperience : ScriptableObject
    {
        [SerializeField]
        private PlayerLevel playerLevel;
        
        public PlayerLevel PlayerLevelData => playerLevel;

        [Button]
        private void AddExperience(int amount = 100)
        {
            playerLevel.AddExperience(amount);
        }

        [Button]
        private void LevelUp()
        {
            playerLevel.LevelUp();
        }
    }
}
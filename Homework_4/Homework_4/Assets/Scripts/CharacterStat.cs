using System;
using EasyButtons;
using UnityEngine;

namespace Homework
{
    [Serializable]
    public sealed class CharacterStat
    {
        public event Action<int> OnValueChanged; 
        
        [field: SerializeField]
        public string Name { get; private set; }
        
        [field: SerializeField]
        public int Value { get; private set; }
        
        public void ChangeValue(int value)
        {
            this.Value = value;
            this.OnValueChanged?.Invoke(value);
        }
    }
}
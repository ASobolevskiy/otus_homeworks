using EasyButtons;
using JetBrains.Annotations;
using UnityEngine;

namespace Homework
{
    [CreateAssetMenu(fileName = "CharacterStat", menuName = "Data/CharacterStat/NewCharacterStat")]
    public class CharacterStatConfig : ScriptableObject
    {
        [SerializeField]
        public CharacterStat stat;

        [Button]
        private void ChangeValue(int val)
        {
            stat.ChangeValue(val);
        }
    }
}
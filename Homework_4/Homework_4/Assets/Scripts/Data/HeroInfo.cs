using UnityEngine;

namespace Homework
{
    [CreateAssetMenu(fileName = "HeroInfo", menuName = "Data/New HeroInfo")]
    public class HeroInfo : ScriptableObject
    {
        [SerializeField]
        private UserInfoObject userInfoObject;

        [Space]
        [SerializeField]
        private CharacterStatConfig[] statsConfigs;

        [Space]
        [SerializeField]
        private HeroExperience heroExperience;

        public UserInfoObject UserInfo => userInfoObject;
        public CharacterStatConfig[] HeroStats => statsConfigs;

        public HeroExperience HeroExperience => heroExperience;
    }
}
using UnityEngine;

namespace Homework
{
    [CreateAssetMenu(fileName = "UserInfo", menuName = "Data/New UserInfo")]
    public class UserInfoObject : ScriptableObject
    {
        [SerializeField]
        private string userName;

        [SerializeField]
        private string description;

        [SerializeField]
        private Sprite icon;

        public string Name => userName;
        public string Description => description;
        public Sprite Icon => icon;
    }
}
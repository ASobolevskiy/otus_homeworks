using UnityEngine;
using UnityEngine.UI;

namespace Homework
{
    public class Portrait : MonoBehaviour
    {
        [SerializeField]
        private Image portrait;

        public void SetPortraitSprite(Sprite icon)
        {
            portrait.sprite = icon;
        }
    }
}
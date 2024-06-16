using EasyButtons;
using UnityEngine;

namespace Homework
{
    public class PopupHelper : MonoBehaviour
    {
        [SerializeField]
        private HeroPopup popup;

        [SerializeField]
        private HeroInfo heroInfo;

        

        [Button]
        public void ShowPopup()
        {
            popup.Show(new HeroPopupPresenter(heroInfo));
        }
    }
}
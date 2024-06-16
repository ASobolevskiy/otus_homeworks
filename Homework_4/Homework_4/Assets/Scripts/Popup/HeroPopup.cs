using System;
using System.Collections.Generic;
using Homework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Homework
{
    public class HeroPopup : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text userNameText;

        [SerializeField]
        private Portrait portrait;

        [SerializeField]
        private TMP_Text description;

        [SerializeField]
        private Button closeButton;

        [SerializeField]
        private Transform container;

        [SerializeField]
        private StatView statViewPrefab;

        [SerializeField]
        private ProgressBar experienceProgressBar;

        [SerializeField]
        private TMP_Text currentLevelText;

        [SerializeField]
        private LevelupButton levelUpButton;

        private readonly List<StatView> views = new();
        private IHeroPopupPresenter _popupPresenter;
        
        public void Show(IPresenter args)
        {
            if (args is not IHeroPopupPresenter popupPresenter)
            {
                throw new Exception("Expected IHeroPopupPresenter!");
            }

            _popupPresenter = popupPresenter;
            
            userNameText.text = popupPresenter.UserInfoPresenter.Name;
            portrait.SetPortraitSprite(popupPresenter.UserInfoPresenter.Icon);
            description.text = popupPresenter.UserInfoPresenter.Description;
            

            foreach (var statPresenter in popupPresenter.StatBlockPresenter.StatPresenters)
            {
                var view = Instantiate(statViewPrefab, container);
                view.Initialize(statPresenter);
                views.Add(view);
            }

            currentLevelText.text = $"Level: {popupPresenter.ExperiencePresenter.CurrentLevel}";
            experienceProgressBar.Initialize(popupPresenter.ExperiencePresenter);
            levelUpButton.SetAvailable(popupPresenter.ExperiencePresenter.CanLevelUp);
            
            closeButton.onClick.AddListener(Hide);
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            closeButton.onClick.RemoveListener(Hide);
            foreach (var view in views)
            {
                Destroy(view.gameObject);
            }
            views.Clear();
        }

        private void CallLevelUp()
        {
            _popupPresenter.ExperiencePresenter.LevelUp();
        }
    }
}
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Homework
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text experienceText;

        [SerializeField]
        private Slider slider;

        [SerializeField]
        private Sprite uncompletedProgessSprite;

        [SerializeField]
        private Sprite completedProgressSprite;

        public void Initialize(IPresenter args)
        {
            if (args is not IExperiencePresenter presenter)
            {
                throw new Exception("Expected IExperiencePresenter!");
            }

            experienceText.text = $"{presenter.CurrentExperience} / {presenter.RequiredExperience}";
            slider.value = (float)presenter.CurrentExperience / presenter.RequiredExperience;
            SetupSliderSprites();
        }
        
        private void SetupSliderSprites()
        {
            var img = slider.fillRect.GetComponent<Image>();
            img.sprite = slider.value < slider.maxValue 
                ? uncompletedProgessSprite 
                : completedProgressSprite;
        }
    }
}
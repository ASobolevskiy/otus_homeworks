using System;
using System.ComponentModel;
using TMPro;
using UnityEngine;

namespace Homework.Views
{
    public class StatView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text statText;

        private IStatPresenter _statPresenter;

        public void Initialize(IPresenter args)
        {
            if (args is not IStatPresenter statPresenter)
            {
                throw new Exception("IStatPresenter expected!");
            }

            _statPresenter = statPresenter;
            statText.text = $"{statPresenter.StatName}: {statPresenter.StatValue}";
            statPresenter.PropertyChanged += HandlePropertyChanged;
        }

        private void OnDestroy()
        {
            _statPresenter.PropertyChanged -= HandlePropertyChanged;
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_statPresenter.StatValue)) 
                statText.text = $"{_statPresenter.StatName}: {_statPresenter.StatValue}";
        }
    }
    
}
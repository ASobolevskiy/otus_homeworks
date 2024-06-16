using System;
using Homework.Enums;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Homework
{
    public class LevelupButton : MonoBehaviour
    {
        [SerializeField]
        private Button levelUpButton;

        [SerializeField]
        private Image background;

        [SerializeField]
        private Sprite availableSprite;

        [SerializeField]
        private Sprite lockedSprite;

        public void AddListener(UnityAction action)
        {
            levelUpButton.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            levelUpButton.onClick.RemoveListener(action);
        }

        public void SetAvailable(bool isAvailable)
        {
            var state = isAvailable ? ButtonState.Available : ButtonState.Locked;
            SetState(state);
        }

        private void SetState(ButtonState state)
        {
            switch (state)
            {
                case ButtonState.Available:
                    levelUpButton.interactable = true;
                    background.sprite = availableSprite;
                    break;
                case ButtonState.Locked:
                    levelUpButton.interactable = false;
                    background.sprite = lockedSprite;
                    break;
                default:
                    throw new Exception($"Undefined button state {state}");
            }
        }
    }
}
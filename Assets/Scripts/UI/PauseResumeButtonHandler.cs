using System;
using DI.Attributes;
using ShootEmUp;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [Serializable]
    public class PauseResumeButtonHandler :
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private Button pauseButton;

        [SerializeField]
        private Button resumeButton;
        
        private GameManager gameManager;

        [Inject]
        public void Construct(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }
        public void OnGameStarted()
        {
            pauseButton.onClick.AddListener(PauseGame);
            resumeButton.onClick.AddListener(ResumeGame);
        }

        public void OnGameFinished()
        {
            pauseButton.onClick.RemoveListener(PauseGame);
            resumeButton.onClick.RemoveListener(ResumeGame);
        }
        
        private void PauseGame()
        {
            gameManager.HandlePause();
        }
        
        private void ResumeGame()
        {
            gameManager.HandleResume();
        }
    }
}
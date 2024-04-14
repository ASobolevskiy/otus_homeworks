using System;
using ShootEmUp;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [Serializable]
    public class PauseResumeButtonStateController :
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private Button pauseButton;

        [SerializeField]
        private Button resumeButton;

        public void OnGameStarted()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
        }

        public void OnGamePaused()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);

        }

        public void OnGameResumed()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);

        }
        public void OnGameFinished()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
        }
    }
}
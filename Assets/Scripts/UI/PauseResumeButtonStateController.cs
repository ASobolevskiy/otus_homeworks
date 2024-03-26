using ShootEmUp;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseResumeButtonStateController : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private Button pauseButton;

        [SerializeField]
        private Button resumeButton;

        private void Awake()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
        }

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
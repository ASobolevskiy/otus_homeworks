using ShootEmUp;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseResumeButtonHandler : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private Button pauseButton;

        [SerializeField]
        private Button resumeButton;
        
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
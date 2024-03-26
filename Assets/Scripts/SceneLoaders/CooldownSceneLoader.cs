using ShootEmUp.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoaders
{
    public class CooldownSceneLoader : MonoBehaviour
    {
        [SerializeField]
        private Timer timer;

        [SerializeField]
        private int sceneIndexToLoad = 1;

        private void Awake()
        {
            timer.OnTimerElapsed += HandleTimerElapsed;
        }

        private void OnDestroy()
        {
            timer.OnTimerElapsed -= HandleTimerElapsed;
        }

        private void HandleTimerElapsed()
        {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
}
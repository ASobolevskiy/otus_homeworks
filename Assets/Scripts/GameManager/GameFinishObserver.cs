using SceneLoaders;
using UnityEngine;

namespace ShootEmUp
{
    public class GameFinishObserver : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private SceneLoader sceneLoader;

        private const int LOADING_SCENE_INDEX = 0;

        private void Awake()
        {
            gameManager.GameFinished += HandleFinishedGame;
        }

        private void OnDestroy()
        {
            gameManager.GameFinished -= HandleFinishedGame;
        }

        private void HandleFinishedGame()
        {
            sceneLoader.LoadScene(LOADING_SCENE_INDEX);
        }
    }
}
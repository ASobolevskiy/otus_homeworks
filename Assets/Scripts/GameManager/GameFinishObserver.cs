using DI.Attributes;
using SceneLoaders;
using UnityEngine;

namespace ShootEmUp
{
    public class GameFinishObserver
    {
        private GameManager gameManager;
        private SceneLoader sceneLoader;

        private const int LOADING_SCENE_INDEX = 0;

        [Inject]
        private void Construct(GameManager gameManager, SceneLoader sceneLoader)
        {
            this.gameManager = gameManager;
            this.sceneLoader = sceneLoader;
            gameManager.GameFinished += HandleFinishedGame;
        }
        
        private void HandleFinishedGame()
        {
            gameManager.GameFinished -= HandleFinishedGame;
            sceneLoader.LoadScene(LOADING_SCENE_INDEX);
        }
    }
}
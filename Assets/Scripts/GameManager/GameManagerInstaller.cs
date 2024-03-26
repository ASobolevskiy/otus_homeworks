using System;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = GetComponent<GameManager>();

            var listeners = GetComponentsInChildren<Listeners.IGameListener>();
            
            Listeners.IGameStartListener[] startGameListeners = GetComponentsInChildren<Listeners.IGameStartListener>();
            Listeners.IGamePauseListener[] pauseGameListeners = GetComponentsInChildren<Listeners.IGamePauseListener>();
            Listeners.IGameResumeListener[] resumeGameListeners = GetComponentsInChildren<Listeners.IGameResumeListener>();
            Listeners.IGameFinishListener[] finishGameListeners = GetComponentsInChildren<Listeners.IGameFinishListener>();
            Listeners.IUpdateListener[] updateListeners = GetComponentsInChildren<Listeners.IUpdateListener>();
            Listeners.IFixedUpdateListener[] fixedUpdateListeners = GetComponentsInChildren<Listeners.IFixedUpdateListener>();
            
            
            
            gameManager.AddGameListeners(listeners);
            gameManager.HandleStart();
        }
    }
}
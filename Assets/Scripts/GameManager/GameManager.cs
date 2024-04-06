using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        public event Action GameFinished;
        
        public GameState GameState { get; private set; } = GameState.None;

        private readonly List<Listeners.IGameListener> gameListeners = new();
        
        public void AddGameListeners(IEnumerable<Listeners.IGameListener> listeners)
        {
            foreach (var listener in listeners)
            {
                AddGameListener(listener);
            }
        }

        public void AddGameListener(Listeners.IGameListener listener)
        {
            gameListeners.Add(listener);
        }

        public void RemoveGameListener(Listeners.IGameListener listener)
        {
            gameListeners.Remove(listener);
        }
        
        public void HandleStart()
        {
            if (GameState != GameState.None)
            {
                return;
            }

            GameState = GameState.Playing;
            
            foreach (var listener in gameListeners)
            {
                if(listener is Listeners.IGameStartListener gameStartListener)
                {
                    gameStartListener.OnGameStarted();
                }
            }
        }

        public void HandlePause()
        {
            if (GameState != GameState.Playing)
            {
                return;
            }

            GameState = GameState.Paused;

            foreach (var listener in gameListeners)
            {
                if (listener is Listeners.IGamePauseListener gamePauseListener)
                {
                    gamePauseListener.OnGamePaused();
                }
            }
        }

        public void HandleResume()
        {
            if (GameState != GameState.Paused)
            {
                return;
            }

            GameState = GameState.Playing;
            
            foreach (var listener in gameListeners)
            {
                if (listener is Listeners.IGameResumeListener gameResumeListener)
                {
                    gameResumeListener.OnGameResumed();
                }
            }
        }

        public void HandleFinish()
        {
            if (GameState is GameState.None or GameState.Finished)
            {
                return;
            }

            foreach (var listener in gameListeners)
            {
                if (listener is Listeners.IGameFinishListener gameFinishListener)
                {
                    gameFinishListener.OnGameFinished();
                }
            }
            
            GameFinished?.Invoke();
        }

        private void Update()
        {
            if (GameState != GameState.Playing)
            {
                return;
            }

            foreach (var listener in gameListeners)
            {
                if (listener is Listeners.IUpdateListener updateListener)
                {
                    updateListener.OnUpdate(Time.deltaTime);
                }
            }
        }

        private void FixedUpdate()
        {
            if (GameState != GameState.Playing)
            {
                return;
            }

            foreach (var listener in gameListeners)
            {
                if (listener is Listeners.IFixedUpdateListener fixedUpdateListener)
                {
                    fixedUpdateListener.OnFixedUpdate(Time.fixedDeltaTime);
                }
            }
        }
    }
}
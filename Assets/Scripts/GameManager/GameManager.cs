using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        public event Action GameFinished;
        
        public GameState GameState { get; private set; } = GameState.None;

        private List<Listeners.IGameListener> gameListeners = new();
        
        private List<Listeners.IGameStartListener> gameStartListeners = new();
        private List<Listeners.IGamePauseListener> gamePauseListeners = new();
        private List<Listeners.IGameResumeListener> gameResumeListeners = new();
        private List<Listeners.IGameFinishListener> gameFinishListeners = new();
        private List<Listeners.IUpdateListener> gameUpdateListeners = new();
        private List<Listeners.IFixedUpdateListener> gameFixedUpdateListeners = new();
        
        public void AddGameListeners(IEnumerable<Listeners.IGameListener> listeners)
        {
            foreach (var t in listeners)
            {
                AddGameListener(t);
            }
        }

        public void AddGameListener(Listeners.IGameListener listener)
        {
            gameListeners.Add(listener);
            if (listener is Listeners.IGameStartListener gameStartListener)
                gameStartListeners.Add(gameStartListener);
            if (listener is Listeners.IGamePauseListener gamePauseListener)
                gamePauseListeners.Add(gamePauseListener);
            if (listener is Listeners.IGameResumeListener gameResumeListener)
                gameResumeListeners.Add(gameResumeListener);
            if (listener is Listeners.IGameFinishListener gameFinishListener)
                gameFinishListeners.Add(gameFinishListener);
            if (listener is Listeners.IUpdateListener gameUpdateListener)
                gameUpdateListeners.Add(gameUpdateListener);
            if (listener is Listeners.IFixedUpdateListener gameFixedUpdateListener) gameFixedUpdateListeners.Add(gameFixedUpdateListener);
        }

        public void RemoveGameListener(Listeners.IGameListener listener)
        {
            gameListeners.Remove(listener);
            if (listener is Listeners.IGameStartListener gameStartListener)
                gameStartListeners.Remove(gameStartListener);
            if (listener is Listeners.IGamePauseListener gamePauseListener)
                gamePauseListeners.Remove(gamePauseListener);
            if (listener is Listeners.IGameResumeListener gameResumeListener)
                gameResumeListeners.Remove(gameResumeListener);
            if (listener is Listeners.IGameFinishListener gameFinishListener)
                gameFinishListeners.Remove(gameFinishListener);
            if (listener is Listeners.IUpdateListener gameUpdateListener)
                gameUpdateListeners.Remove(gameUpdateListener);
            if (listener is Listeners.IFixedUpdateListener gameFixedUpdateListener) gameFixedUpdateListeners.Remove(gameFixedUpdateListener);
        }
        
        public void HandleStart()
        {
            if(GameState == GameState.None)
            {
                Debug.Log("Game started!");
                GameState = GameState.Playing;
                Time.timeScale = 1;
                gameStartListeners.ForEach(l => l.OnGameStarted());
            }
            else
            {
                Debug.Log("Game is already running!");
            }
        }

        public void HandlePause()
        {
            if(GameState == GameState.Playing)
            {
                Debug.Log("Game paused!");
                GameState = GameState.Paused;
                Time.timeScale = 0;
                gamePauseListeners.ForEach(l => l.OnGamePaused());
            }
            else
            {
                Debug.Log("Cannot pause not running game!");
            }
            
        }

        public void HandleResume()
        {
            if(GameState == GameState.Paused)
            {
                Debug.Log("Game resumed!");
                GameState = GameState.Playing;
                Time.timeScale = 1;
                gameResumeListeners.ForEach(l => l.OnGameResumed());
            }
            else
            {
                Debug.Log("Cannot resume: game is not paused!");
            }
        }

        public void HandleFinish()
        {
            if(GameState != GameState.None && GameState != GameState.Finished)
            {
                Debug.Log("Game finished!");
                GameState = GameState.Finished;
                Time.timeScale = 0;
                gameFinishListeners.ForEach(l => l.OnGameFinished());
                GameFinished?.Invoke();
            }
            else
            {
                Debug.Log("Game is not started yet!");
            }
        }

        private void Update()
        {
            if (GameState != GameState.Playing) 
                return;
            for (int i = 0; i < gameUpdateListeners.Count; i++)
            {
                gameUpdateListeners[i].OnUpdate(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (GameState != GameState.Playing) return;
            for (int i = 0; i < gameFixedUpdateListeners.Count; i++)
            {
                gameFixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }
    }
}
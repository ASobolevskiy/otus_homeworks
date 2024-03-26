using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyCooldownSpawner : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private EnemySpawner enemySpawner;

        [SerializeField]
        private float spawnDelayInSeconds = 1f;
        
        private bool isGameRunning = true;

        private IEnumerator StartSpawning()
        {
            while (isGameRunning)
            {
                yield return new WaitForSeconds(spawnDelayInSeconds);
                enemySpawner.SpawnEnemy();
            }
        }
        
        public void OnGameStarted()
        {
            isGameRunning = true;
            StartCoroutine(StartSpawning());
        }

        public void OnGamePaused()
        {
            isGameRunning = false;
            StopCoroutine(StartSpawning());
        }

        public void OnGameResumed()
        {
            isGameRunning = true;
            StartCoroutine(StartSpawning());
        }

        public void OnGameFinished()
        {
            isGameRunning = false;
            StopCoroutine(StartSpawning());
        }
    }
}
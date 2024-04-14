using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using DI.Attributes;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public class EnemyCooldownSpawner :
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private float spawnDelayInSeconds = 1f;
        
        private bool isGameRunning = true;
        private EnemySpawner enemySpawner;
        private CancellationTokenSource cts;

        [Inject]
        public void Construct(EnemySpawner enemySpawner)
        {
            this.enemySpawner = enemySpawner;
        }

        private async Task StartSpawningTask(CancellationToken ct)
        {
            while (isGameRunning && !ct.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(spawnDelayInSeconds));
                enemySpawner.SpawnEnemy();
            }
        }
        
        public void OnGameStarted()
        {
            isGameRunning = true;
            cts = new CancellationTokenSource();
            _ = StartSpawningTask(cts.Token);
        }

        public void OnGamePaused()
        {
            isGameRunning = false;
            cts.Cancel();
            cts.Dispose();
        }

        public void OnGameResumed()
        {
            isGameRunning = true;
            cts = new CancellationTokenSource();
            _ = StartSpawningTask(cts.Token);
        }

        public void OnGameFinished()
        {
            isGameRunning = false;
            cts.Cancel();
            cts.Dispose();
        }
    }
}
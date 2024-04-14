using System.Collections.Generic;
using DI.Attributes;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager :
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        private EnemySpawner enemySpawner;
        private readonly HashSet<GameObject> activeEnemies = new();

        [Inject]
        public void Construct(EnemySpawner enemySpawner)
        {
            this.enemySpawner = enemySpawner;
        }

        public void OnGameStarted()
        {
            enemySpawner.OnEnemySpawned += HandleSpawnedEnemy;
        }
        
        public void OnGameFinished()
        {
            enemySpawner.OnEnemySpawned -= HandleSpawnedEnemy;
        }

        private void HandleSpawnedEnemy(GameObject enemy)
        {
            if (!activeEnemies.Add(enemy))
            {
                return;
            }

            if(enemy.TryGetComponent(out HitPointsComponent hpComponent))
            {
                hpComponent.OnHpEmpty += OnDestroyed;
            }

            if (enemy.TryGetComponent(out EnemyDestinationReachedObserver enemyDestinationReachedObserver))
            {
                enemyDestinationReachedObserver.Activate();
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (!activeEnemies.Remove(enemy))
            {
                return;
            }

            if (enemy.TryGetComponent(out HitPointsComponent hpComponent))
            {
                hpComponent.OnHpEmpty -= OnDestroyed;
            }
            if (enemy.TryGetComponent(out EnemyDestinationReachedObserver enemyDestinationReachedObserver))
            {
                enemyDestinationReachedObserver.Deactivate();
            }

            enemySpawner.RemoveDestroyedEnemy(enemy);
        }
    }
}
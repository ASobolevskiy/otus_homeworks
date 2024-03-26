using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private EnemySpawner enemySpawner;
        
        private readonly HashSet<GameObject> activeEnemies = new();

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
                return;
            if(enemy.TryGetComponent(out HitPointsComponent hpComponent))
                hpComponent.OnHpEmpty += OnDestroyed;
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (!activeEnemies.Remove(enemy)) 
                return;
            if (enemy.TryGetComponent(out HitPointsComponent hpComponent))
                hpComponent.OnHpEmpty -= OnDestroyed;
            enemySpawner.RemoveDestroyedEnemy(enemy);
        }
    }
}
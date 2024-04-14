using System;
using DI.Attributes;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySpawner
    {
        public event Action<GameObject> OnEnemySpawned;
        
        private EnemyPositions enemyPositions;
        private Transform worldTransform;
        private GameManager gameManager;
        private GameObject character;
        private BulletSystem bulletSystem;
        private EnemyPool enemyPool;
        private GameObject currentEnemy;

        [Inject]
        public void Construct(EnemyPool enemyPool, BulletSystem bulletSystem, GameObject character, GameManager gameManager, Transform worldTransform, EnemyPositions enemyPositions)
        {
            this.enemyPool = enemyPool;
            this.bulletSystem = bulletSystem;
            this.character = character;
            this.gameManager = gameManager;
            this.worldTransform = worldTransform;
            this.enemyPositions = enemyPositions;
        }

        public void SpawnEnemy()
        {
            if(enemyPool.TryDequeueEnemy(out currentEnemy))
            {
                currentEnemy.transform.SetParent(worldTransform);
                RestoreHpIfNeeded();
                SetSpawnPosition();
                SetAttackPosition();
                RegisterListeners();
                OnEnemySpawned?.Invoke(currentEnemy);
            }
        }
        
        private void RestoreHpIfNeeded()
        {
            if (!currentEnemy.TryGetComponent(out HitPointsComponent hpComponent))
            {
                return;
            }

            if(!hpComponent.IsHitPointsExists())
            {
                hpComponent.RestoreHpToMax();
            }
        }
        
        private void SetSpawnPosition()
        {
            var spawnPosition = enemyPositions.RandomSpawnPosition();
            currentEnemy.transform.position = spawnPosition.position;
        }
        
        private void SetAttackPosition()
        {
            var attackPosition = enemyPositions.RandomAttackPosition();
            if (currentEnemy.TryGetComponent(out EnemyMoveAgent moveAgent))
            {
                moveAgent.SetDestination(attackPosition.position);
            }
            
        }

        private void RegisterListeners()
        {
            if (currentEnemy.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
            {
                gameManager.AddGameListener(enemyAttackAgent);
            }
            if(currentEnemy.TryGetComponent(out EnemyMoveAgent enemyMoveAgent))
            {
                gameManager.AddGameListener(enemyMoveAgent);
            }
            if(currentEnemy.TryGetComponent(out MoveComponentBase moveComponent))
            {
                gameManager.AddGameListener(moveComponent);
            }
        }

        public void RemoveDestroyedEnemy(GameObject enemy)
        {
            UnregisterListeners(enemy);
            enemyPool.EnqueueEnemy(enemy);
        }

        private void UnregisterListeners(GameObject enemy)
        {
            if (enemy.TryGetComponent(out EnemyAttackAgent attackAgent))
            {
                gameManager.RemoveGameListener(attackAgent);
            }
            if (enemy.TryGetComponent(out EnemyMoveAgent enemyMoveAgent))
            {
                gameManager.RemoveGameListener(enemyMoveAgent);
            }
            if (enemy.TryGetComponent(out MoveComponentBase moveComponent))
            {
                gameManager.RemoveGameListener(moveComponent);
            }
        }
    }
}
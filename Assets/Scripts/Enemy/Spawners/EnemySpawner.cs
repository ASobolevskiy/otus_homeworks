using System;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour
    {
        public event Action<GameObject> OnEnemySpawned;
        
        [SerializeField]
        private EnemyPositions enemyPositions;

        [SerializeField]
        private EnemyPool enemyPool;
        

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private GameObject character;

        [SerializeField]
        private BulletSystem bulletSystem;

        private GameObject currentEnemy;

        public void SpawnEnemy()
        {
            if(enemyPool.TryDequeueEnemy(out currentEnemy))
            {
                currentEnemy.transform.SetParent(worldTransform);
                RestoreHpIfNeeded();
                SetSpawnPosition();
                SetAttackPosition();
                if (currentEnemy.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
                {
                    enemyAttackAgent.SetTarget(character);
                    enemyAttackAgent.SetBulletSystem(bulletSystem);
                }
                OnEnemySpawned?.Invoke(currentEnemy);
            }
        }
        
        public void RemoveDestroyedEnemy(GameObject enemy)
        {
            if (enemy.TryGetComponent(out EnemyAttackAgent attackAgent))
            {
                attackAgent.SetReadyForAttack(false);
            }
            enemyPool.EnqueueEnemy(enemy);
        }

        private void RestoreHpIfNeeded()
        {
            if (!currentEnemy.TryGetComponent(out HitPointsComponent hpComponent)) return;
            if(!hpComponent.IsHitPointsExists())
                hpComponent.RestoreHpToMax();
        }
        
        private void SetSpawnPosition()
        {
            var spawnPosition = enemyPositions.RandomSpawnPosition();
            currentEnemy.transform.position = spawnPosition.position;
        }
        
        private void SetAttackPosition()
        {
            var attackPosition = enemyPositions.RandomAttackPosition();
            currentEnemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
        }
    }
}
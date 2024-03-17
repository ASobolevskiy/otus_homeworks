using UnityEngine;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyPositions enemyPositions;

        [SerializeField]
        private EnemyPool enemyPool;

        [SerializeField]
        private int maxSpawnedEnemies;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private GameObject character;

        private GameObject currentEnemy;

        private void Awake()
        {
            enemyPool.FillEnemyQueue(maxSpawnedEnemies);
        }

        public GameObject SpawnEnemy()
        {
            currentEnemy = enemyPool.DequeueEnemy();
            if (currentEnemy != null)
            {
                currentEnemy.transform.SetParent(worldTransform);
                RestoreHpIfNeeded();
                SetSpawnPosition();
                SetAttackPosition();
                if (currentEnemy.TryGetComponent(out EnemyAttackAgent attackAgent))
                {
                    attackAgent.SetTarget(character);
                }
            }

            return currentEnemy;
        }
        
        public void RemoveDestroyedEnemy(GameObject enemy) => enemyPool.EnqueueEnemy(enemy);

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
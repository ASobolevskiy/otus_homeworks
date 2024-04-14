using System;
using DI.Attributes;
using UnityEngine;

namespace ShootEmUp.Factories
{
    [Serializable]
    public class EnemyFactory
    {
        [SerializeField]
        private GameObject enemyPrefab;

        private BulletSystem bulletSystem;
        private GameObject character;

        [Inject]
        public void Construct(BulletSystem bulletSystem, GameObject character)
        {
            this.bulletSystem = bulletSystem;
            this.character = character;
        }

        public GameObject CreateEnemy(Transform container)
        {
            var enemy = UnityEngine.Object.Instantiate(enemyPrefab, container);
            if(enemy.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
            {
                enemyAttackAgent.SetBulletSystem(bulletSystem);
                enemyAttackAgent.SetTarget(character);
            }
            return enemy;
        }
    }
}
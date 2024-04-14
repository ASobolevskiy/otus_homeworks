using System;
using System.Collections.Generic;
using DI.Attributes;
using ShootEmUp.Factories;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyPool : 
        Listeners.IGameStartListener
    {
        [Header("Pool")]
        [SerializeField]
        private Transform container;
        
        [SerializeField]
        public int maxEnemies = 7;

        private readonly Queue<GameObject> enemyPool = new();
        private EnemyFactory enemyFactory;

        [Inject]
        public void Construct(EnemyFactory enemyFactory)
        {
            this.enemyFactory = enemyFactory;
        }
        public void OnGameStarted()
        {
            for (var i = 0; i < maxEnemies; i++)
            {
                var enemy = enemyFactory.CreateEnemy(container);
                enemyPool.Enqueue(enemy);
            }
        }
        
        public bool TryDequeueEnemy(out GameObject enemy) => enemyPool.TryDequeue(out enemy);
        
        public void EnqueueEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(container);
            enemyPool.Enqueue(enemy);
        }
    }
}
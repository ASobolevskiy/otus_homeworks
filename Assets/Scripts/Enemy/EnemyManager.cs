using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner enemySpawner;
        
        [SerializeField]
        private BulletSystem bulletSystem;
        
        private readonly HashSet<GameObject> activeEnemies = new();
        
        //TODO sinc with gameManager
        private readonly bool isGameRunning = true;

        private IEnumerator Start()
        {
            while (isGameRunning)
            {
                yield return new WaitForSeconds(1);
                var enemy = enemySpawner.SpawnEnemy();
                if (enemy != null)
                {
                    if (activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().OnHpEmpty += OnDestroyed;
                    }    
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty -= OnDestroyed;
                enemySpawner.RemoveDestroyedEnemy(enemy);
            }
        }


    }
}
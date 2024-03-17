using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyCooldownSpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner enemySpawner;

        [SerializeField]
        private float spawnDelayInSeconds = 1f;

        //TODO Link up with gamestate
        private readonly bool isGameRunning = true;

        private IEnumerator Start()
        {
            while (isGameRunning)
            {
                yield return new WaitForSeconds(spawnDelayInSeconds);
                enemySpawner.SpawnEnemy();
            }
        }
    }
}
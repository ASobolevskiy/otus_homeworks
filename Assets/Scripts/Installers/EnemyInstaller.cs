using System;
using System.Collections.Generic;
using ShootEmUp.DI;
using ShootEmUp.Factories;
using UnityEngine;

namespace ShootEmUp.Installers
{
    public class EnemyInstaller : BaseInstaller,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider
    {
        [SerializeField]
        private EnemyPool enemyPool;

        [Space]
        [SerializeField]
        private EnemyPositions enemyPositions;

        [Space]
        [SerializeField]
        private EnemyCooldownSpawner enemyCooldownSpawner;

        [SerializeField]
        private EnemyFactory enemyFactory;
        
        private readonly EnemySpawner enemySpawner = new();
        private readonly EnemyManager enemyManager = new();
        
        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return enemyPool;
            yield return enemyManager;
            yield return enemyCooldownSpawner;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(EnemyPool), enemyPool);
            yield return (typeof(EnemyPositions), enemyPositions);
            yield return (typeof(EnemySpawner), enemySpawner);
            yield return (typeof(EnemyFactory), enemyFactory);
        }
    }
}